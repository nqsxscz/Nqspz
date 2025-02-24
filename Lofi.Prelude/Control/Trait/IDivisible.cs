using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

/// <summary>
/// </summary>
/// <typeparam name="TC"></typeparam>
public interface IDivisible<TC>
    : IContravariant<TC>
    where TC : IDivisible<TC>
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static abstract ITypeConstructor<TC, T> Conquer<T>()
        where T : notnull;

    /// <summary>
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <returns></returns>
    static abstract ITypeConstructor<TC, T1>
        Divide<T1, T2, T3>(
            ITypeConstructor<TC, T2> left,
            ITypeConstructor<TC, T3> right,
            Func<T1, (T2, T3)> f)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}