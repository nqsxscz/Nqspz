using Algebra.Operators;

namespace Algebra.Groups.Additive;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IAdditiveGroup<T, TOperator> 
    : IAdditiveMonoid<T, TOperator>, IGroup<T, TOperator>
    where T : IAdditiveGroup<T, TOperator>
    where TOperator : IAddBinaryOperator;