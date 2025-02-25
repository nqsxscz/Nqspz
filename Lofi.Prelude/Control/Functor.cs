using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

public static class Functor
{
    public static ITypeConstructor<TC, T2> Select<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        Func<T1, T2> selector)
        where TC : IFunctor<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.Select(input, selector);
}