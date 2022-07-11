using System;

namespace SharpPdb.Windows;

public class MemoryLoadedFile
{
    private string path;
    public string Path => this.path;

    public int Length { get; set; }
    public unsafe byte* BasePointer { get; set; }

    public MemoryLoadedFile(string path)
    {
        this.path = path;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}