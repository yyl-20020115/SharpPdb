﻿using SharpPdb.Windows.Utility;

namespace SharpPdb.Windows.TypeRecords;

/// <summary>
/// Represents string list type record.
/// </summary>
public class StringListRecord : TypeRecord
{
    /// <summary>
    /// Array of <see cref="TypeLeafKind"/> that this class can read.
    /// </summary>
    public static readonly TypeLeafKind[] Kinds = new TypeLeafKind[]
    {
        TypeLeafKind.LF_SUBSTR_LIST
    };

    /// <summary>
    /// List of type indices for describing the strings.
    /// </summary>
    public TypeIndex[] StringIndices { get; private set; }

    /// <summary>
    /// Reads <see cref="ModifierRecord"/> from the stream.
    /// </summary>
    /// <param name="reader">Stream binary reader.</param>
    /// <param name="kind">Type record kind.</param>
    public static StringListRecord Read(IBinaryReader reader, TypeLeafKind kind)
    {
        uint count = reader.ReadUint();
        TypeIndex[] strings = new TypeIndex[count];

        for (int i = 0; i < strings.Length; i++)
            strings[i] = TypeIndex.Read(reader);
        return new StringListRecord
        {
            Kind = kind,
            StringIndices = strings,
        };
    }
}
