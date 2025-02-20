using Algebra.Operators;

namespace Algebra.Groups.Additive;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IAdditiveSemigroup<T, TOperator>
    : ISemigroup<T, TOperator>
    where T : IAdditiveSemigroup<T, TOperator>
    where TOperator : IAddBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract T Add(T left, T right);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static T ISemigroup<T, TOperator>.Combine(T left, T right) 
        => T.Add(left, right);
}