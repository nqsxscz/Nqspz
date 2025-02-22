using Algebra.Operators;

namespace Algebra.Groups.Additive;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAdditiveSemigroup<T>
    : ISemigroup<T, IAddBinaryOperator>
    where T : IAdditiveSemigroup<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract T operator +(T left, T right);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static T ISemigroup<T, IAddBinaryOperator>.Combine(T left, T right) 
        => left + right;
}