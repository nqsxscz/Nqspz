using Algebra.Operators;

namespace Algebra.Groups;

public interface IMonoid<T, TOperator> 
    : ISemigroup<T, TOperator>
    where T : IMonoid<T, TOperator>
    where TOperator : IBinaryOperator
{
    static abstract T Identity { get; }
}