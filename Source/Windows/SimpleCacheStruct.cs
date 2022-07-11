using System.Collections.Generic;

namespace SharpPdb.Windows
{
    public class SimpleCacheStruct<T>
    {
        public T Value { get; internal set; }

        //public static SimpleCacheStruct<T> operator T(T value)
        //{
        //    return null;
        //}
            
    }
}