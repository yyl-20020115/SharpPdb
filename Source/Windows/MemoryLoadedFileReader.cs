namespace SharpPdb.Windows
{
    internal class MemoryLoadedFileReader : MemoryLoadedFile
    {
        private MemoryLoadedFile file;

        public MemoryLoadedFileReader(MemoryLoadedFile file)
        {
            this.file = file;
        }
    }
}