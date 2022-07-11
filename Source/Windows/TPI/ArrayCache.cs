using SharpPdb.Windows.TypeRecords;
using System;

namespace SharpPdb.Windows.TPI
{
    internal class ArrayCache<T>
    {
        private int count;
        private bool v;
        private Func<int, TypeRecord> readType;

        public ArrayCache(int count, bool v, Func<int, TypeRecord> readType)
        {
            this.count = count;
            this.v = v;
            this.readType = readType;
        }
    }
}