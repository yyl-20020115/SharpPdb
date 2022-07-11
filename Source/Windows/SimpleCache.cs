using System;

namespace SharpPdb.Windows;

public class SimpleCache
{
    public static SimpleCacheStruct<T> CreateStruct<T>(Func<T, T> value)
    {
        throw new NotImplementedException();
    }

    public static SimpleCacheStruct<T> CreateStruct<T>(Func<T> value)
    {
        throw new NotImplementedException();
    }
    public static SimpleCacheWithContext<T2, T1> CreateWithContext<T1, T2>(T1 dbiModuleDescriptor, Func<T1, T2> callEnumerateFiles)
    {
        throw new NotImplementedException();
    }
    public static SimpleCacheWithContext<T1[], T2> CreateWithContext<T1, T2>(T1 dbiModuleDescriptor, Func<T1, T2[]> callEnumerateFiles)
    {
        throw new NotImplementedException();
    }
    public static SimpleCacheWithContext<T2[], T1> CreateWithContext2<T1, T2>(T1 dbiModuleDescriptor, Func<T1, T2[]> callEnumerateFiles)
    {
        throw new NotImplementedException();
    }
    public static SimpleCacheWithContext<T1[], T2> CreateWithContext<T1, T2>(T2 dbiModuleDescriptor, Func<T1, T2[]> callEnumerateFiles)
    {
        throw new NotImplementedException();
    }

}