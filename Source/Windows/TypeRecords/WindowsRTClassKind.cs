﻿#pragma warning disable 1591

namespace SharpPdb.Windows.TypeRecords;

public enum WindowsRTClassKind : byte
{
    None = 0x00,
    RefClass = 0x01,
    ValueClass = 0x02,
    Interface = 0x03
}
