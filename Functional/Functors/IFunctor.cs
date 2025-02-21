using Functional.HigherKindedTypes;

namespace Functional.Functors;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TC"></typeparam>
public interface IFunctor<TC>
    where TC : IFunctor<TC>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static abstract ITypeConstructor<TC, T2> Select<T1, T2>(
        ITypeConstructor<TC, T1> input, 
        Func<T1, T2> selector);
}