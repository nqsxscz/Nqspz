using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IMultiplicativeSemigroup<T, TOperator>
    : ISemigroup<T, TOperator>
    where T : IMultiplicativeSemigroup<T, TOperator>
    where TOperator : IMultiplyBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract T Multiply(T left, T right);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static T ISemigroup<T, TOperator>.Combine(T left, T right) 
        => T.Multiply(left, right);
}