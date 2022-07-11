using System;

namespace SharpPdb.Windows;

public class MemoryLoadedFile
{
    private string path;

    public MemoryLoadedFile(string path)
    {
        this.path = path;
    }

    internal void Dispose()
    {
        throw new NotImplementedException();
    }
}