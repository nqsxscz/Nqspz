using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

public interface IMultiplicativeGroup<T, TOperator> 
    : IMultiplicativeMonoid<T, TOperator>, IGroup<T, TOperator>
    where T : IMultiplicativeGroup<T, TOperator>
    where TOperator : IMultiplyBinaryOperator;