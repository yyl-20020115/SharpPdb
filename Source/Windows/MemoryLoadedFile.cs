using System;

namespace SharpPdb.Windows;

public class MemoryLoadedFile
{
    private string path;
    public string Path => this.path;
    public MemoryLoadedFile(string path)
    {
        this.path = path;
    }

    internal void Dispose()
    {
        throw new NotImplementedException();
    }
}