using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

/// <summary>
/// </summary>
public static class Monad
{
    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TC, T2> SelectMany<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        Func<T1, ITypeConstructor<TC, T2>> selector)
        where TC : IMonad<TC>
        where T1 : notnull
        where T2 : notnull
    {
        return TC.SelectMany(input, selector);
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="f"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TC, T3> SelectMany<TC, T1, T2, T3>(
        this ITypeConstructor<TC, T1> input,
        Func<T1, ITypeConstructor<TC, T2>> f,
        Func<T1, T2, T3> selector)
        where TC : IMonad<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
    {
        return input.SelectMany(t1 =>
            f(t1).Select(t2 =>
                selector(t1, t2)));
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TC, T> Flatten<TC, T>(
        this ITypeConstructor<TC, ITypeConstructor<TC, T>> input)
        where TC : IMonad<TC>
        where T : notnull
    {
        return input.SelectMany(x => x);
    }
}