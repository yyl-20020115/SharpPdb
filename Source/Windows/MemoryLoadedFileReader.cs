namespace SharpPdb.Windows;

public class MemoryLoadedFileReader : MemoryLoadedFile
{
    private MemoryLoadedFile file;
    private string path;
    public MemoryLoadedFileReader(MemoryLoadedFile file)
    {
        this.file = file;
    }
    public MemoryLoadedFileReader(string path)
    {
        this.path = path;
    }
}
