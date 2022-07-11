using SharpPdb.Windows.TypeRecords;
using System;

namespace SharpPdb.Windows.TPI
{
    internal class DictionaryCache<T1, T2>
    {
        private Func<TypeLeafKind, TypeRecord[]> getTypesByKind;

        public DictionaryCache(Func<TypeLeafKind, TypeRecord[]> getTypesByKind)
        {
            this.getTypesByKind = getTypesByKind;
        }
    }
}