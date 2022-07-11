﻿

namespace SharpPdb.Windows.SymbolRecords
{
    /// <summary>
    /// Represents procedure symbol from the symbols stream.
    /// </summary>
    public class ProcedureSymbol : SymbolRecord
    {
        /// <summary>
        /// Array of <see cref="SymbolRecordKind"/> that this class can read.
        /// </summary>
        public static readonly SymbolRecordKind[] Kinds = new SymbolRecordKind[]
        {
            SymbolRecordKind.S_GPROC32, SymbolRecordKind.S_LPROC32, SymbolRecordKind.S_GPROC32_ID,
            SymbolRecordKind.S_LPROC32_ID, SymbolRecordKind.S_LPROC32_DPC, SymbolRecordKind.S_LPROC32_DPC_ID
        };

        /// <summary>
        /// Used in local procedures, global procedures, thunk start, with start, and
        /// block start symbols. If the scope is not enclosed by another lexical scope,
        /// then <see cref="ParentOffset"/> is zero. Otherwise, the parent of this scope is the symbol
        /// within this module that opens the outer scope that encloses this scope but
        /// encloses no other scope that encloses this scope. The <see cref="ParentOffset"/> field contains
        /// the offset from the beginning of the module's symbol table of the symbol
        /// that opens the enclosing lexical scope.
        /// </summary>
        public uint ParentOffset { get; private set; }

        /// <summary>
        /// Used in start search local procedures, global procedures, and thunk start
        /// symbols. The <see cref="Next"/> field, along with the start search symbol, defines a
        /// group of lexically scoped symbols within a symbol table that is contained
        /// within a code segment or PE section. For each segment or section
        /// represented in the symbol table, there is a start search symbol that contains
        /// the offset from the start of the symbols for this module to the first procedure
        /// or thunk contained in the segment. Each outermost lexical scope symbol
        /// has a next field containing the next outermost scope symbol contained in the
        /// segment. The last outermost scope in the symbol table for each segment has
        /// a next field of zero.
        /// </summary>
        public uint End { get; private set; }

        /// <summary>
        /// This field is defined for local procedures, global procedures, thunk, block,
        /// and with symbols.The end field contains the offset from the start of the
        /// symbols for this module to the matching block end symbol that terminates
        /// the lexical scope.
        /// </summary>
        public uint Next { get; private set; }

        /// <summary>
        /// Gets the length in bytes of this procedure.
        /// </summary>
        public uint CodeSize { get; private set; }

        /// <summary>
        /// Gets the offset in bytes from the start of the procedure to the point where the
        /// stack frame has been set up. Parameter and frame variables can be viewed at this point.
        /// </summary>
        public uint DebugStart { get; private set; }

        /// <summary>
        /// Gets the offset in bytes from the start of the procedure to the point where the
        /// procedure is ready to return and has calculated its return value, if any.
        /// Frame and register variables can still be viewed.
        /// </summary>
        public uint DebugEnd { get; private set; }

        /// <summary>
        /// Gets the function type.
        /// </summary>
        public TypeIndex FunctionType { get; private set; }

        /// <summary>
        /// Gets the offset portion of the procedure address.
        /// </summary>
        public uint Offset { get; private set; }

        /// <summary>
        /// Gets the segment portion of the procedure address.
        /// </summary>
        public ushort Segment { get; private set; }

        /// <summary>
        /// Gets the procedure flags.
        /// </summary>
        public ProcedureFlags Flags { get; private set; }

        /// <summary>
        /// Gets the name of procedure.
        /// </summary>
        public StringReference Name;

        /// <summary>
        /// Reads <see cref="ProcedureSymbol"/> from the stream.
        /// </summary>
        /// <param name="reader">Stream binary reader.</param>
        /// <param name="symbolStream">Symbol stream that contains this symbol record.</param>
        /// <param name="symbolStreamIndex">Index in symbol stream <see cref="SymbolStream.References"/> array.</param>
        /// <param name="kind">Symbol record kind.</param>
        public static ProcedureSymbol Read(IBinaryReader reader, SymbolStream symbolStream, int symbolStreamIndex, SymbolRecordKind kind)
        {
            return new ProcedureSymbol
            {
                SymbolStream = symbolStream,
                SymbolStreamIndex = symbolStreamIndex,
                Kind = kind,
                ParentOffset = reader.ReadUint(),
                End = reader.ReadUint(),
                Next = reader.ReadUint(),
                CodeSize = reader.ReadUint(),
                DebugStart = reader.ReadUint(),
                DebugEnd = reader.ReadUint(),
                FunctionType = TypeIndex.Read(reader),
                Offset = reader.ReadUint(),
                Segment = reader.ReadUshort(),
                Flags = (ProcedureFlags)reader.ReadByte(),
                Name = reader.ReadCString(),
            };
        }

        /// <summary>
        /// Gets end position of the children subrecords.
        /// </summary>
        /// <returns>Position in the binary stream.</returns>
        protected override long GetChildrenEndPosition()
        {
            return End;
        }

        /// <summary>
        /// Gets the position in the symbol stream of the parent symbol record.
        /// </summary>
        /// <returns>Position in the symbol stream of the parent symbol record.</returns>
        protected override long GetParentPosition()
        {
            return ParentOffset;
        }
    }
}
