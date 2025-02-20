using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

public interface IMultiplicativeMonoid<T, TOperator> 
    : IMultiplicativeSemigroup<T, TOperator>, IMonoid<T, TOperator>
    where T : IMultiplicativeMonoid<T, TOperator>
    where TOperator : IMultiplyBinaryOperator
{
    static abstract T MultiplicativeIdentity { get; }
    
    static T IMonoid<T, TOperator>.Identity => T.MultiplicativeIdentity;
}