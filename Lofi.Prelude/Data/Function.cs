namespace Lofi.Prelude.Data;

/// <summary>
/// </summary>
public static class Function
{
    /// <summary>
    /// </summary>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static Func<T1, Func<T2, T3>>
        Curry<T1, T2, T3>(this Func<T1, T2, T3> f)
    {
        return t1
            => t2
                => f(t1, t2);
    }

    /// <summary>
    /// </summary>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3>
        Uncurry<T1, T2, T3>(this Func<T1, Func<T2, T3>> f)
    {
        return (t1, t2)
            => f(t1)(t2);
    }

    /// <summary>
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static Func<T1, T3> AndThen<T1, T2, T3>(
        this Func<T1, T2> f1,
        Func<T2, T3> f2)
    {
        return t1
            => f2(f1(t1));
    }

    /// <summary>
    /// </summary>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static Func<T2, T1, T3> Flip<T1, T2, T3>(
        this Func<T1, T2, T3> f)
    {
        return (t2, t1)
            => f(t1, t2);
    }
}