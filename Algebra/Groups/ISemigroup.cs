using Algebra.Operators;

namespace Algebra.Groups;

public interface ISemigroup<T, TOperator>
    where T : ISemigroup<T, TOperator>
    where TOperator : IBinaryOperator
{
    static abstract T Combine(T left, T right);
}