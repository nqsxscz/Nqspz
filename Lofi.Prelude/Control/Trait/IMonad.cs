using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

/// <summary>
/// </summary>
/// <typeparam name="TC"></typeparam>
public interface IMonad<TC>
    : IApplicative<TC>
    where TC : IMonad<TC>
{
    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<TC, T2> IFunctor<TC>.Select<T1, T2>(
        ITypeConstructor<TC, T1> input,
        Func<T1, T2> selector)
    {
        return input.SelectMany(
            t1 => TC.MReturn(selector(t1)));
    }

    /// <summary>
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<TC, T> IApplicative<TC>.Pure<T>(T t)
    {
        return TC.MReturn(t);
    }

    /// <summary>
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<TC, T3> IApplicative<TC>.Lift<T1, T2, T3>(
        ITypeConstructor<TC, T1> left,
        ITypeConstructor<TC, T2> right,
        Func<T1, T2, T3> selector)
    {
        return from t1 in left
            from t2 in right
            select selector(t1, t2);
    }

    /// <summary>
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static abstract ITypeConstructor<TC, T> MReturn<T>(T t)
        where T : notnull;

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static abstract ITypeConstructor<TC, T2> SelectMany<T1, T2>(
        ITypeConstructor<TC, T1> input,
        Func<T1, ITypeConstructor<TC, T2>> selector)
        where T1 : notnull
        where T2 : notnull;
}