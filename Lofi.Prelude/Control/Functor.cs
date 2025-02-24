using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

/// <summary>
/// </summary>
public static class Functor
{
    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="selector"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static ITypeConstructor<TC, T2> Select<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        Func<T1, T2> selector)
        where TC : IFunctor<TC>
        where T1 : notnull
        where T2 : notnull
    {
        return TC.Select(input, selector);
    }
}