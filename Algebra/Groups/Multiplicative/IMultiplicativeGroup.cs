using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IMultiplicativeGroup<T, TOperator> 
    : IMultiplicativeMonoid<T, TOperator>, IGroup<T, TOperator>
    where T : IMultiplicativeGroup<T, TOperator>
    where TOperator : IMultiplyBinaryOperator;