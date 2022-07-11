using System;

namespace SharpPdb.Windows.Utility;

public class BinaryReader : IBinaryReader
{
    public long Length => throw new NotImplementedException();

    public long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int BytesRemaining => throw new NotImplementedException();

    public void Align(int v)
    {
        throw new NotImplementedException();
    }

    public IBinaryReader Duplicate()
    {
        throw new NotImplementedException();
    }

    public void Move(ushort dataLen)
    {
        throw new NotImplementedException();
    }

    public void Move(uint bytes)
    {
        throw new NotImplementedException();
    }

    public byte[] ReadAllBytes()
    {
        throw new NotImplementedException();
    }

    public object ReadBString()
    {
        throw new NotImplementedException();
    }

    public MemoryBuffer ReadBuffer(uint length)
    {
        throw new NotImplementedException();
    }

    public byte ReadByte()
    {
        throw new NotImplementedException();
    }

    public byte[] ReadByteArray(int v)
    {
        throw new NotImplementedException();
    }

    public unsafe void ReadBytes(byte* bytes, uint count)
    {
        throw new NotImplementedException();
    }

    public StringReference ReadCString()
    {
        throw new NotImplementedException();
    }

    public StringReference ReadCStringWide()
    {
        throw new NotImplementedException();
    }

    public object ReadDecimal()
    {
        throw new NotImplementedException();
    }

    public object ReadDouble()
    {
        throw new NotImplementedException();
    }

    public object ReadFloat()
    {
        throw new NotImplementedException();
    }

    public Guid ReadGuid()
    {
        throw new NotImplementedException();
    }

    public int ReadInt()
    {
        throw new NotImplementedException();
    }

    public long ReadLong()
    {
        throw new NotImplementedException();
    }

    public short ReadShort()
    {
        throw new NotImplementedException();
    }

    public IBinaryReader ReadSubstream(uint hashLength)
    {
        throw new NotImplementedException();
    }

    public IBinaryReader ReadSubstream(long hashLength)
    {
        throw new NotImplementedException();
    }

    public IBinaryReader ReadSubstream()
    {
        throw new NotImplementedException();
    }

    public uint ReadUint()
    {
        throw new NotImplementedException();
    }

    public uint[] ReadUintArray(int entries)
    {
        throw new NotImplementedException();
    }

    public ulong ReadUlong()
    {
        throw new NotImplementedException();
    }

    public ushort ReadUshort()
    {
        throw new NotImplementedException();
    }

    public ushort[] ReadUshortArray(int modulesCount)
    {
        throw new NotImplementedException();
    }
}