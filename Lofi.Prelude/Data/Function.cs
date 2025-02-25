namespace Lofi.Prelude.Data;

public static class Function
{
    public static Func<T1, Func<T2, T3>>
        Curry<T1, T2, T3>(this Func<T1, T2, T3> f)
        => t1
            => t2
                => f(t1, t2);

    public static Func<T1, T2, T3>
        Uncurry<T1, T2, T3>(this Func<T1, Func<T2, T3>> f)
        => (t1, t2)
            => f(t1)(t2);
    
    public static Func<T1, T3> AndThen<T1, T2, T3>(
        this Func<T1, T2> f1,
        Func<T2, T3> f2)
        => t1 
            => f2(f1(t1));

    public static Func<T2, T1, T3> Flip<T1, T2, T3>(
        this Func<T1, T2, T3> f)
        => (t2, t1)
            => f(t1, t2);
}