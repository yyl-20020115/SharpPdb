﻿

namespace SharpPdb.Windows.SymbolRecords
{
    /// <summary>
    /// Represents trampoline symbol record.
    /// </summary>
    public class TrampolineSymbol : SymbolRecord
    {
        /// <summary>
        /// Array of <see cref="SymbolRecordKind"/> that this class can read.
        /// </summary>
        public static readonly SymbolRecordKind[] Kinds = new SymbolRecordKind[]
        {
            SymbolRecordKind.S_TRAMPOLINE
        };

        /// <summary>
        /// Gets the trampoline type.
        /// </summary>
        public TrampolineType Type { get; private set; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public ushort Size { get; private set; }

        /// <summary>
        /// Gets the thunk offset.
        /// </summary>
        public uint ThunkOffset { get; private set; }

        /// <summary>
        /// Gets the target offset.
        /// </summary>
        public uint TargetOffset { get; private set; }

        /// <summary>
        /// Gets the thunk section.
        /// </summary>
        public ushort ThunkSection { get; private set; }

        /// <summary>
        /// Gets the target section.
        /// </summary>
        public ushort TargetSection { get; private set; }

        /// <summary>
        /// Reads <see cref="TrampolineSymbol"/> from the stream.
        /// </summary>
        /// <param name="reader">Stream binary reader.</param>
        /// <param name="symbolStream">Symbol stream that contains this symbol record.</param>
        /// <param name="symbolStreamIndex">Index in symbol stream <see cref="SymbolStream.References"/> array.</param>
        /// <param name="kind">Symbol record kind.</param>
        public static TrampolineSymbol Read(IBinaryReader reader, SymbolStream symbolStream, int symbolStreamIndex, SymbolRecordKind kind)
        {
            return new TrampolineSymbol
            {
                SymbolStream = symbolStream,
                SymbolStreamIndex = symbolStreamIndex,
                Kind = kind,
                Type = (TrampolineType)reader.ReadUshort(),
                Size = reader.ReadUshort(),
                ThunkOffset = reader.ReadUint(),
                TargetOffset = reader.ReadUint(),
                ThunkSection = reader.ReadUshort(),
                TargetSection = reader.ReadUshort(),
            };
        }
    }
}
