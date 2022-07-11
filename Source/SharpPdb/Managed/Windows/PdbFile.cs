﻿using SharpPdb.Windows;
using SharpPdb.Windows.DBI;
using SharpPdb.Windows.DebugSubsections;
using SharpPdb.Windows.SymbolRecords;
using SharpPdb.Windows.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpPdb.Managed.Windows
{
    /// <summary>
    /// Represents Windows PDB file reader.
    /// </summary>
    public class PdbFile : IPdbFile
    {
        /// <summary>
        /// File loaded into memory for faster parsing.
        /// </summary>
        private MemoryLoadedFile file;

        /// <summary>
        /// Cache for <see cref="Functions"/> property.
        /// </summary>
        private SimpleCacheStruct<List<IPdbFunction>> functionsCache;

        /// <summary>
        /// Cache for source files accessed by indexing operator.
        /// </summary>
        private DictionaryCache<FileChecksumSubsection, PdbSource> sourcesCache;

        /// <summary>
        /// Cache for <see cref="FunctionsByToken"/> property.
        /// </summary>
        private SimpleCacheStruct<Dictionary<int, IPdbFunction>> functionsByTokenCache;

        /// <summary>
        /// Cache for <see cref="TokenRidMap"/> property.
        /// </summary>
        private SimpleCacheStruct<uint[]> tokenRidMapCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdbFile"/> class.
        /// </summary>
        /// <param name="file">File loaded into memory for faster parsing.</param>
        public PdbFile(MemoryLoadedFile file)
        {
            Reader = new SharpPdb.Windows.PdbFile(file);
            functionsCache = SimpleCache.CreateStruct(() =>
            {
                List<IPdbFunction> functions = new List<IPdbFunction>();

                foreach (var dbiModule in Reader.DbiStream.Modules)
                {
                    var symbolStream = dbiModule.LocalSymbolStream;

                    foreach (var kind in ManagedProcedureSymbol.Kinds)
                        foreach (ManagedProcedureSymbol procedure in symbolStream[kind])
                            functions.Add(new PdbFunction(this, procedure, dbiModule));
                }
                return functions;
            });
            sourcesCache = new DictionaryCache<FileChecksumSubsection, PdbSource>(checksum => new PdbSource(this, checksum));
            functionsByTokenCache = SimpleCache.CreateStruct(() => Functions.ToDictionary(f => f.Token));
            tokenRidMapCache = SimpleCache.CreateStruct(() =>
            {
                var reader = Reader.DbiStream.GetKnownDebugStream(KnownDebugStreamIndex.TokenRidMap)?.Reader;

                if (reader == null)
                    return null;

                int count = (int)(reader.Length / 4); // 4 = sizeof(uint)
                uint[] tokenRidMap = new uint[count];

                for (int i = 0; i < count; i++)
                    tokenRidMap[i] = reader.ReadUint();
                return tokenRidMap;
            });
            this.file = file;
        }

        /// <summary>
        /// Gets the Windows PDB reader.
        /// </summary>
        internal SharpPdb.Windows.PdbFile Reader { get; private set; }

        /// <summary>
        /// Gets the <c>/names</c> stream.
        /// </summary>
        public PdbStringTable NamesStream => Reader.InfoStream.NamesMap;

        /// <summary>
        /// Gets the PDB file info stream header.
        /// </summary>
        public SharpPdb.Windows.PIS.InfoStreamHeader PdbId => Reader.InfoStream.Header;

        /// <summary>
        /// Dictionary of available functions indexed by its token.
        /// </summary>
        internal Dictionary<int, IPdbFunction> FunctionsByToken => functionsByTokenCache.Value;

        /// <summary>
        /// Gets the token remapping table if exists.
        /// </summary>
        internal uint[] TokenRidMap => tokenRidMapCache.Value;

        /// <summary>
        /// Gets the PDB file identifier.
        /// </summary>
        public Guid Guid => PdbId.Guid;

        /// <summary>
        /// Gets the PDB stamp.
        /// </summary>
        public uint Stamp => PdbId.Signature;

        /// <summary>
        /// Gets the PDB file age.
        /// </summary>
        public int Age => (int)PdbId.Age;

        /// <summary>
        /// Gets the list of functions described in this PDB file.
        /// </summary>
        public IReadOnlyList<IPdbFunction> Functions => functionsCache.Value;

        internal PdbSource this[FileChecksumSubsection checksum] => sourcesCache[checksum];

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            file?.Dispose();
        }

        /// <summary>
        /// Find function by the specified token.
        /// </summary>
        /// <param name="token">Method definition token.</param>
        /// <returns><see cref="IPdbFunction"/> object if found, <c>null</c> otherwise.</returns>
        public IPdbFunction GetFunctionFromToken(int token)
        {
            IPdbFunction function = null;

            FunctionsByToken.TryGetValue(token, out function);
            return function;
        }
    }
}
