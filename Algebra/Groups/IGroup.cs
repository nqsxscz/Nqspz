using Algebra.Operators;

namespace Algebra.Groups;

public interface IGroup<T, TOperator> 
    : IMonoid<T, TOperator>
    where T : IGroup<T, TOperator>
    where TOperator : IBinaryOperator
{
    static abstract T Invert(T operand);
}