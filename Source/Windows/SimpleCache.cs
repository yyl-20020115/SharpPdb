using SharpPdb.Windows.DBI;
using System;
using System.Collections.Generic;

namespace SharpPdb.Windows
{
    internal class SimpleCache
    {
        internal static SimpleCacheStruct<T> CreateStruct<T>(Func<T, T> value)
        {
            throw new NotImplementedException();
        }
        internal static SimpleCacheStruct<T> CreateStruct<T>(Func<T> value)
        {
            throw new NotImplementedException();
        }
        internal static SimpleCacheWithContext<string[], DbiModuleDescriptor> CreateWithContext(DbiModuleDescriptor dbiModuleDescriptor, Func<DbiModuleDescriptor, string[]> callEnumerateFiles)
        {
            throw new NotImplementedException();
        }

        internal static SimpleCacheWithContext<PdbStream, DbiModuleDescriptor> CreateWithContext(DbiModuleDescriptor dbiModuleDescriptor, Func<DbiModuleDescriptor, PdbStream> callEnumerateModuleStream)
        {
            throw new NotImplementedException();
        }

        internal static SimpleCacheWithContext<SymbolStream, DbiModuleDescriptor> CreateWithContext(DbiModuleDescriptor dbiModuleDescriptor, Func<DbiModuleDescriptor, SymbolStream> callEnumerateLocalSymbolStream)
        {
            throw new NotImplementedException();
        }

        internal static SimpleCacheWithContext<DebugSubsectionStream, DbiModuleDescriptor> CreateWithContext(DbiModuleDescriptor dbiModuleDescriptor, Func<DbiModuleDescriptor, DebugSubsectionStream> callEnumerateDebugSubsectionStream)
        {
            throw new NotImplementedException();
        }
    }
}