using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

public static class Applicative
{
    public static ITypeConstructor<TC, T3> Lift<TC, T1, T2, T3>(
        this ITypeConstructor<TC, T1> left,
        ITypeConstructor<TC, T2> right,
        Func<T1, T2, T3> selector)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => TC.Lift(left, right, selector);
    
    public static ITypeConstructor<TC, T2> Apply<TC, T1, T2>(
        this ITypeConstructor<TC, Func<T1, T2>> f,
        ITypeConstructor<TC, T1> input)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        => f.Sequence()(input);
    
    public static ITypeConstructor<TC, T2> Apply<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        ITypeConstructor<TC, Func<T1, T2>> f)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        => f.Apply(input);

    public static Func<ITypeConstructor<TC, T1>, ITypeConstructor<TC, T2>>
        Sequence<TC, T1, T2>(
            this ITypeConstructor<TC, Func<T1, T2>> f)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        => input
            => Lift(
                f,
                input,
                (g, t1) => g(t1));
}