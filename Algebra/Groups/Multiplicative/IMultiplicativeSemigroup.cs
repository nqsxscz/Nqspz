using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMultiplicativeSemigroup<T>
    : ISemigroup<T, IMultiplyBinaryOperator>
    where T : IMultiplicativeSemigroup<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract T operator *(T left, T right);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static T ISemigroup<T, IMultiplyBinaryOperator>.Combine(T left, T right) 
        => left * right;
}