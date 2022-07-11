using System.Text;

namespace SharpPdb.Windows.Utility;

public class StringReference
{
    private Encoding uTF8;

    public StringReference(MemoryBuffer buffer, Encoding uTF8)
    {
        Buffer = buffer;
        this.uTF8 = uTF8;
    }

    public static Encoding Encoding { get; internal set; }
    public MemoryBuffer Buffer { get; internal set; }
    public string String { get; internal set; }
}