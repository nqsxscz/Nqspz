using Algebra.Operators;

namespace Algebra.Groups.Additive;

public interface IAdditiveGroup<T, TOperator> 
    : IAdditiveMonoid<T, TOperator>, IGroup<T, TOperator>
    where T : IAdditiveGroup<T, TOperator>
    where TOperator : IAddBinaryOperator;