using Algebra.Operators;

namespace Algebra.Groups;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface ISemigroup<T, TOperator>
    where T : ISemigroup<T, TOperator>
    where TOperator : IBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract T Combine(T left, T right);
}