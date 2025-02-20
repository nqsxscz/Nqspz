using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IMultiplicativeMonoid<T, TOperator> 
    : IMultiplicativeSemigroup<T, TOperator>, IMonoid<T, TOperator>
    where T : IMultiplicativeMonoid<T, TOperator>
    where TOperator : IMultiplyBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    static abstract T MultiplicativeIdentity { get; }
    
    /// <summary>
    /// 
    /// </summary>
    static T IMonoid<T, TOperator>.Identity => T.MultiplicativeIdentity;
}