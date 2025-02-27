namespace Lofi.Prelude.Data;

public static class Function
{
    public static Func<T1, Func<T2, T3>>
        Curry<T1, T2, T3>(this Func<T1, T2, T3> f)
        => t1
            => t2
                => f(t1, t2);
    
    public static Func<T1, T2, Func<T3, T4>>
        Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> f)
        => (t1, t2)
            => t3
                => f(t1, t2, t3);
    
    public static Func<T1, T2, T3, Func<T4, T5>>
        Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> f)
        => (t1, t2, t3)
            => t4
                => f(t1, t2, t3, t4);

    public static Func<T1, T2, T3>
        Uncurry<T1, T2, T3>(this Func<T1, Func<T2, T3>> f)
        => (t1, t2)
            => f(t1)(t2);
    
    public static Func<T1, T2, T3, T4>
        Uncurry<T1, T2, T3, T4>(this Func<T1, T2, Func<T3, T4>> f)
        => (t1, t2, t3)
            => f(t1, t2)(t3);
    
    public static Func<T1, T2, T3, T4, T5>
        Uncurry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, Func<T4, T5>> f)
        => (t1, t2, t3, t4)
            => f(t1, t2, t3)(t4);
    
    public static Func<T1, T3> AndThen<T1, T2, T3>(
        this Func<T1, T2> f1,
        Func<T2, T3> f2)
        => t1 
            => f2(f1(t1));

    public static Func<T2, T1, T3> Flip<T1, T2, T3>(
        this Func<T1, T2, T3> f)
        => (t2, t1)
            => f(t1, t2);
    
    public static (T1, T2) Tuple2<T1, T2>(
        T1 t1, 
        T2 t2)
        => (t1, t2);
    
    public static (T1, T2, T3) Tuple3<T1, T2, T3>(
        T1 t1, 
        T2 t2, 
        T3 t3)
        => (t1, t2, t3);
    
    public static (T1, T2, T3, T4) Tuple4<T1, T2, T3, T4>(
        T1 t1, 
        T2 t2, 
        T3 t3, 
        T4 t4)
        => (t1, t2, t3, t4);
}