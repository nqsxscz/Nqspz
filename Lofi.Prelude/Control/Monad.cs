using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

public static class Monad
{
    public static ITypeConstructor<TC, T2> SelectMany<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        Func<T1, ITypeConstructor<TC, T2>> selector)
        where TC : IMonad<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.SelectMany(input, selector);
    
    public static ITypeConstructor<TC, T3> SelectMany<TC, T1, T2, T3>(
        this ITypeConstructor<TC, T1> input,
        Func<T1, ITypeConstructor<TC, T2>> f,
        Func<T1, T2, T3> selector)
        where TC : IMonad<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => input.SelectMany(t1 =>
            f(t1).Select(t2 =>
                selector(t1, t2)));

    public static ITypeConstructor<TC, T> Flatten<TC, T>(
        this ITypeConstructor<TC, ITypeConstructor<TC, T>> input)
        where TC : IMonad<TC>
        where T : notnull
        => input.SelectMany(x => x);
}