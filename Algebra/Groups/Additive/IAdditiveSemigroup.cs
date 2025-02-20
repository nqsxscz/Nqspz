using Algebra.Operators;

namespace Algebra.Groups.Additive;

public interface IAdditiveSemigroup<T, TOperator>
    : ISemigroup<T, TOperator>
    where T : IAdditiveSemigroup<T, TOperator>
    where TOperator : IAddBinaryOperator
{
    static abstract T Add(T left, T right);
    
    static T ISemigroup<T, TOperator>.Combine(T left, T right) 
        => T.Add(left, right);
}