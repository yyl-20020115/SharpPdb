﻿

namespace SharpPdb.Managed
{
    /// <summary>
    /// Helper functions for reading PDB files.
    /// </summary>
    public static class PdbFileReader
    {
        /// <summary>
        /// Opens PDB file from the specified path. It supports both Portable PDB and Windows PDB format.
        /// </summary>
        /// <param name="path">Path to the PDB file.</param>
        public static IPdbFile OpenPdb(string path)
        {
            // Load file into memory.
            MemoryLoadedFile file = new MemoryLoadedFile(path);

            // Check if it is Portable PDB file.
            try
            {
                return new Portable.PdbFile(file);
            }
            catch
            {
            }

            // Check if it is Windows PDB file.
            try
            {
                return new Windows.PdbFile(file);
            }
            catch
            {
            }

            // Check if it is Portable PDB file that is embedded in the assembly.
            try
            {
                return new Portable.EmbeddedPdbFile(file);
            }
            catch
            {
            }

            // Unload file from memory.
            file.Dispose();
            return null;
        }
    }
}
