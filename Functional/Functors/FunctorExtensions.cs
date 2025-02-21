using Functional.HigherKindedTypes;

namespace Functional.Functors;

/// <summary>
/// 
/// </summary>
public static class FunctorExtensions
{
    /// <summary>
    /// 
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
        => TC.Select(input, selector);
}