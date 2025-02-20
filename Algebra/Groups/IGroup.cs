using Algebra.Operators;

namespace Algebra.Groups;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IGroup<T, TOperator> 
    : IMonoid<T, TOperator>
    where T : IGroup<T, TOperator>
    where TOperator : IBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operand"></param>
    /// <returns></returns>
    static abstract T Invert(T operand);
}