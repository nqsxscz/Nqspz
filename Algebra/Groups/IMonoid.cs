using Algebra.Operators;

namespace Algebra.Groups;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IMonoid<T, TOperator> 
    : ISemigroup<T, TOperator>
    where T : IMonoid<T, TOperator>
    where TOperator : IBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    static abstract T Identity { get; }
}