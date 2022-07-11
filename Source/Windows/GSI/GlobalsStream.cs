﻿using SharpPdb.Windows.SymbolRecords;
using SharpPdb.Windows.Utility;
using System;
using System.Collections.Generic;

namespace SharpPdb.Windows.GSI;

/// <summary>
/// Represents PDB globals stream.
/// </summary>
public class GlobalsStream
{
    /// <summary>
    /// Cache for counting on bits in a byte.
    /// </summary>
    private static byte[] bitCount;

    /// <summary>
    /// Cache for <see cref="Constants"/> property.
    /// </summary>
    private SimpleCacheStruct<List<ConstantSymbol>> constantsCache;

    /// <summary>
    /// Cache for <see cref="Data"/> property.
    /// </summary>
    private SimpleCacheStruct<List<DataSymbol>> dataCache;

    /// <summary>
    /// Cache for <see cref="ThreadLocalData"/> property.
    /// </summary>
    private SimpleCacheStruct<List<ThreadLocalDataSymbol>> threadLocalDataCache;

    /// <summary>
    /// Initializes the <see cref="GlobalsStream"/> class.
    /// </summary>
    static GlobalsStream()
    {
        bitCount = new byte[256];
        for (int i = 0; i < 256; i++)
        {
            byte bits = 0;

            for (int j = i; j != 0; j = j >> 1)
                if (j % 2 == 1)
                    bits++;
            bitCount[i] = bits;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalsStream"/> class.
    /// </summary>
    /// <param name="stream">PDB stream that contains globals stream.</param>
    public GlobalsStream(PdbStream stream)
        : this(stream.File, stream.Reader)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalsStream"/> class.
    /// </summary>
    /// <param name="file">PDB file containing this stream.</param>
    /// <param name="reader">Binary stream reader.</param>
    public GlobalsStream(PdbFile file, IBinaryReader reader)
    {
        File = file;

        // Read header
        Header = GlobalsStreamHeader.Read(reader);
        if (Header.Signature != GlobalsStreamHeader.ExpectedSignature)
            throw new Exception($"GSIHashHeader signature (0x{GlobalsStreamHeader.ExpectedSignature:X}) not found.");
        if (Header.Version != GlobalsStreamHeader.ExpectedVersion)
            throw new Exception("Encountered unsupported globals stream version.");

        // Read hash records
        if (Header.HashRecordsSubstreamSize % GlobalsStreamHashRecord.Size != 0)
            throw new Exception("Invalid hash record array size.");
        if (reader.BytesRemaining < Header.HashRecordsSubstreamSize)
            throw new Exception("Error reading hash records.");
        GlobalsStreamHashRecord[] hashRecords = new GlobalsStreamHashRecord[Header.HashRecordsSubstreamSize / GlobalsStreamHashRecord.Size];
        for (int i = 0; i < hashRecords.Length; i++)
            hashRecords[i] = GlobalsStreamHashRecord.Read(reader);
        HashRecords = hashRecords;

        // Read hash buckets
        if (Header.HashBucketsSubstreamSize > 0)
        {
            const uint IPHR_HASH = 4096;
            const uint SizeOfHROffsetCalc = 12;
            ulong bitmapSizeInBits = (IPHR_HASH / 32 + 1) * 32;
            int bitmapEntriesCount = (int)(bitmapSizeInBits / 8);
            if (reader.BytesRemaining < bitmapEntriesCount)
                throw new Exception("Could not read a bitmap.");
            byte[] hashBitmap = reader.ReadByteArray(bitmapEntriesCount);
            int nonEmptyBucketsCount = 0;

            for (int i = 0; i < hashBitmap.Length; i++)
                nonEmptyBucketsCount += bitCount[hashBitmap[i]];
            if (reader.BytesRemaining < nonEmptyBucketsCount * 4) // 4 = sizeof(uint)
                throw new Exception("Could not read a bitmap.");
            uint[] nonEmptyBucketOffsets = reader.ReadUintArray(nonEmptyBucketsCount);
            GlobalsStreamHashBucket[] hashBuckets = new GlobalsStreamHashBucket[IPHR_HASH];

            for (int i = 0, j = 0; i < IPHR_HASH; i++)
            {
                int byteIndex = i / 8;
                int bitIndex = i % 8;

                if ((hashBitmap[byteIndex] & (1 << bitIndex)) != 0)
                {
                    uint start = nonEmptyBucketOffsets[j++] / SizeOfHROffsetCalc;
                    uint end = j < nonEmptyBucketOffsets.Length ? nonEmptyBucketOffsets[j] / SizeOfHROffsetCalc : (uint)HashRecords.Length;

                    hashBuckets[i] = new GlobalsStreamHashBucket
                    {
                        Start = (int)start,
                        End = (int)end,
                    };
                }
                else
                    hashBuckets[i] = new GlobalsStreamHashBucket
                    {
                        Start = -1,
                        End = -1,
                    };
            }

            HashBuckets = hashBuckets;
        }

        Symbols = new ArrayCache<SymbolRecord>(HashRecords.Length, index => File.PdbSymbolStream.GetSymbolRecordByOffset(HashRecords[index].Offset - 1));
        constantsCache = SimpleCache.CreateStruct(() =>
        {
            List<ConstantSymbol> constants = new List<ConstantSymbol>();
            for (int i = 0; i < Symbols.Count; i++)
            {
                ConstantSymbol constant = Symbols[i] as ConstantSymbol;

                if (constant != null)
                    constants.Add(constant);
            }
            return constants;
        });
        threadLocalDataCache = SimpleCache.CreateStruct(() =>
        {
            List<ThreadLocalDataSymbol> threadLocalData = new List<ThreadLocalDataSymbol>();
            for (int i = 0; i < Symbols.Count; i++)
            {
                ThreadLocalDataSymbol tls = Symbols[i] as ThreadLocalDataSymbol;

                if (tls != null)
                    threadLocalData.Add(tls);
            }
            return threadLocalData;
        });
        dataCache = SimpleCache.CreateStruct(() =>
        {
            List<DataSymbol> data = new List<DataSymbol>();
            for (int i = 0; i < Symbols.Count; i++)
            {
                DataSymbol d = Symbols[i] as DataSymbol;

                if (d != null)
                    data.Add(d);
            }
            return data;
        });
    }

    /// <summary>
    /// Gets the PDB file containing this globals stream.
    /// </summary>
    public PdbFile File { get; private set; }

    /// <summary>
    /// Gets globals stream header.
    /// </summary>
    public GlobalsStreamHeader Header { get; private set; }

    /// <summary>
    /// Gets the hash records.
    /// </summary>
    public GlobalsStreamHashRecord[] HashRecords { get; private set; }

    /// <summary>
    /// Gets the all referenced symbols from the symbols stream.
    /// </summary>
    public ArrayCache<SymbolRecord> Symbols { get; private set; }

    /// <summary>
    /// Gets the dictionary of all constants in symbols by name.
    /// </summary>
    public IReadOnlyList<ConstantSymbol> Constants => constantsCache.Value;

    /// <summary>
    /// Gets the dictionary of all data in symbols by name.
    /// </summary>
    public IReadOnlyList<DataSymbol> Data => dataCache.Value;

    /// <summary>
    /// Gets the dictionary of all TLS data in symbols by name.
    /// </summary>
    public IReadOnlyList<ThreadLocalDataSymbol> ThreadLocalData => threadLocalDataCache.Value;

    /// <summary>
    /// Gets the hash buckets.
    /// </summary>
    /// <remarks>
    /// Bucket items are sorted using memcmp.
    /// </remarks>
    public GlobalsStreamHashBucket[] HashBuckets { get; private set; }
}
