using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

/// <summary>
/// </summary>
/// <typeparam name="TC"></typeparam>
public interface IFoldable<TC>
    where TC : IFoldable<TC>
{
    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="init"></param>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static abstract T2 AggregateRight<T1, T2>(
        ITypeConstructor<TC, T1> input,
        T2 init,
        Func<T1, T2, T2> f)
        where T1 : notnull
        where T2 : notnull;
}