using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

/// <summary>
/// </summary>
public static class Applicative
{
    /// <summary>
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TC, T3> Lift<TC, T1, T2, T3>(
        this ITypeConstructor<TC, T1> left,
        ITypeConstructor<TC, T2> right,
        Func<T1, T2, T3> selector)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
    {
        return TC.Lift(left, right, selector);
    }

    /// <summary>
    /// </summary>
    /// <param name="f"></param>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TC, T2> Apply<TC, T1, T2>(
        this ITypeConstructor<TC, Func<T1, T2>> f,
        ITypeConstructor<TC, T1> input)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
    {
        return f.Sequence()(input);
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="f"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TC, T2> Apply<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        ITypeConstructor<TC, Func<T1, T2>> f)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
    {
        return f.Apply(input);
    }

    /// <summary>
    /// </summary>
    /// <param name="f"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static Func<ITypeConstructor<TC, T1>, ITypeConstructor<TC, T2>>
        Sequence<TC, T1, T2>(
            this ITypeConstructor<TC, Func<T1, T2>> f)
        where TC : IApplicative<TC>
        where T1 : notnull
        where T2 : notnull
    {
        return input
            => Lift(
                f,
                input,
                (g, t1) => g(t1));
    }
}