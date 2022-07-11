using System;

namespace SharpPdb.Windows;

public class SimpleCache
{
    internal static SimpleCacheStruct<T> CreateStruct<T>(Func<T, T> value)
    {
        throw new NotImplementedException();
    }
    internal static SimpleCacheStruct<T> CreateStruct<T>(Func<T> value)
    {
        throw new NotImplementedException();
    }
    internal static SimpleCacheWithContext<T2, T1> CreateWithContext<T1, T2>(T1 dbiModuleDescriptor, Func<T1, T2> callEnumerateFiles)
    {
        throw new NotImplementedException();
    }
    internal static SimpleCacheWithContext<T1[], T2> CreateWithContext<T1, T2>(T1 dbiModuleDescriptor, Func<T1, T2[]> callEnumerateFiles)
    {
        throw new NotImplementedException();
    }
    internal static SimpleCacheWithContext<T1[], T2> CreateWithContext<T1, T2>(T2 dbiModuleDescriptor, Func<T1, T2[]> callEnumerateFiles)
    {
        throw new NotImplementedException();
    }

}