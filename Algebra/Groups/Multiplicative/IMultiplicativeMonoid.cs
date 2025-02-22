using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMultiplicativeMonoid<T> 
    : IMultiplicativeSemigroup<T>, IMonoid<T, IMultiplyBinaryOperator>
    where T : IMultiplicativeMonoid<T>
{
    /// <summary>
    /// 
    /// </summary>
    static abstract T One { get; }
    
    /// <summary>
    /// 
    /// </summary>
    static T IMonoid<T, IMultiplyBinaryOperator>.Identity 
        => T.One;
}