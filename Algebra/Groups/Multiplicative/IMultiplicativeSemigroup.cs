using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

public interface IMultiplicativeSemigroup<T, TOperator>
    : ISemigroup<T, TOperator>
    where T : IMultiplicativeSemigroup<T, TOperator>
    where TOperator : IMultiplyBinaryOperator
{
    static abstract T Multiply(T left, T right);
    
    static T ISemigroup<T, TOperator>.Combine(T left, T right) 
        => T.Multiply(left, right);
}