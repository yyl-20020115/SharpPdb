using System.Collections.Generic;

namespace SharpPdb.Windows
{
    public class SimpleCacheStruct<T>
    {
        public Dictionary<T, T> Value { get; internal set; }
    }
}