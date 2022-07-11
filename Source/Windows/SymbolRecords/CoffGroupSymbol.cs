﻿using SharpPdb.Windows.DBI;
using SharpPdb.Windows.Utility;

namespace SharpPdb.Windows.SymbolRecords;

/// <summary>
/// Represents COFF group symbol record.
/// </summary>
public class CoffGroupSymbol : SymbolRecord
{
    /// <summary>
    /// Array of <see cref="SymbolRecordKind"/> that this class can read.
    /// </summary>
    public static readonly SymbolRecordKind[] Kinds = new SymbolRecordKind[]
    {
        SymbolRecordKind.S_COFFGROUP
    };

    /// <summary>
    /// Gets the size.
    /// </summary>
    public uint Size { get; private set; }

    /// <summary>
    /// Gets the COFF group characteristics.
    /// </summary>
    public ImageSectionCharacteristics Characteristics { get; private set; }

    /// <summary>
    /// Gets the offset portion of symbol address.
    /// </summary>
    public uint Offset { get; private set; }

    /// <summary>
    /// Gets the segment portion of symbol address.
    /// </summary>
    public ushort Segment { get; private set; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public StringReference Name;

    /// <summary>
    /// Reads <see cref="CoffGroupSymbol"/> from the stream.
    /// </summary>
    /// <param name="reader">Stream binary reader.</param>
    /// <param name="symbolStream">Symbol stream that contains this symbol record.</param>
    /// <param name="symbolStreamIndex">Index in symbol stream <see cref="SymbolStream.References"/> array.</param>
    /// <param name="kind">Symbol record kind.</param>
    public static CoffGroupSymbol Read(IBinaryReader reader, SymbolStream symbolStream, int symbolStreamIndex, SymbolRecordKind kind)
    {
        return new CoffGroupSymbol
        {
            SymbolStream = symbolStream,
            SymbolStreamIndex = symbolStreamIndex,
            Kind = kind,
            Size = reader.ReadUint(),
            Characteristics = (ImageSectionCharacteristics)reader.ReadUint(),
            Offset = reader.ReadUint(),
            Segment = reader.ReadUshort(),
            Name = reader.ReadCString(),
        };
    }
}
