namespace SharpPdb.Windows.Utility;

public class MemoryBuffer
{
    public MemoryBuffer(byte[] bytes)
    {
        Bytes = bytes;
    }

    public byte[] Bytes { get; internal set; }
}