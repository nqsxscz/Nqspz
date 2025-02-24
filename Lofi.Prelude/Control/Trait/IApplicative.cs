using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

/// <summary>
/// </summary>
/// <typeparam name="TC"></typeparam>
public interface IApplicative<TC>
    : IFunctor<TC>
    where TC : IApplicative<TC>
{
    /// <summary>
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static abstract ITypeConstructor<TC, T> Pure<T>(T t)
        where T : notnull;

    /// <summary>
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    static abstract ITypeConstructor<TC, T3> Lift<T1, T2, T3>(
        ITypeConstructor<TC, T1> left,
        ITypeConstructor<TC, T2> right,
        Func<T1, T2, T3> selector)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}