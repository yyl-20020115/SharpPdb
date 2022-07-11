using System;

namespace SharpPdb.Windows.Utility;

public interface IBinaryReader
{
    int Length { get; }
    long Position { get; set; }
    int BytesRemaining { get; }

    byte[] ReadByteArray(int v);

    uint ReadUint();

    ushort ReadUshort();
    int ReadInt();
    byte ReadByte();
    void Align(int v);
    IBinaryReader ReadSubstream(int hashLength);
    IBinaryReader ReadSubstream(uint hashLength);
    void Move(ushort dataLen);
    IBinaryReader Duplicate();
    short ReadShort();
    long ReadLong();
    ulong ReadUlong();
    StringReference ReadCString();
    StringReference ReadCStringWide();
    unsafe void ReadBytes(byte* bytes, uint count);
    void Move(uint bytes);
    MemoryBuffer ReadBuffer(uint length);
    uint[] ReadUintArray(int entries);
    object ReadFloat();
    object ReadDouble();
    object ReadBString();
    object ReadDecimal();
    ushort[] ReadUshortArray(int modulesCount);
    IBinaryReader ReadSubstream();
    Guid ReadGuid();
}