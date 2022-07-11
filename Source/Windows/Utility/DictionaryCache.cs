using System;

namespace SharpPdb.Windows.Utility;

public class DictionaryCache<T1, T2>
{
    public Func<T1, T2> func;

    public DictionaryCache(Func<T1, T2> func)
    {
        this.func = func;
    }

    public T2 this[T1 key]
    {
        get
        {
            return default(T2);
        }
        set
        {

        }
    }
}