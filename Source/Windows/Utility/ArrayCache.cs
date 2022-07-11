using SharpPdb.Windows.SymbolRecords;
using SharpPdb.Windows.TypeRecords;
using System;

namespace SharpPdb.Windows.Utility;

public class ArrayCache<T>
{
    private int count;
    private bool v;
    private Func<int, T> f;
    private int length;


    public ArrayCache(int count, bool v, Func<int, T> f)
    {
        this.count = count;
        this.v = v;
        this.f = f;
    }
    public ArrayCache(int count, Func<int, T> f)
    {
        this.count = count;
        this.v = false;
        this.f = f;
    }
    public int Count { get; internal set; }

    public T this[int i] => default(T);
}