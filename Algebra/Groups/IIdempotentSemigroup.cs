using Algebra.Operators;

namespace Algebra.Groups;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IIdempotentSemigroup<T, TOperator>
    : ISemigroup<T, TOperator>
    where T : IIdempotentSemigroup<T, TOperator>
    where TOperator : IBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract T IdemCombine(T left, T right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static T ISemigroup<T, TOperator>.Combine(T left, T right)
        => left.Equals(right) ? 
            left : T.IdemCombine(left, right);
}