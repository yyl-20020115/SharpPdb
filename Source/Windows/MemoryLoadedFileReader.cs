namespace SharpPdb.Windows;

public class MemoryLoadedFileReader : MemoryLoadedFile
{
    private MemoryLoadedFile file;
    public MemoryLoadedFileReader(MemoryLoadedFile file)
        :base(file.Path)
    {
        this.file = file;
    }
}
