using Algebra.Operators;

namespace Algebra.Groups.Additive;

public interface IAdditiveMonoid<T, TOperator> 
    : IAdditiveSemigroup<T, TOperator>, IMonoid<T, TOperator>
    where T : IAdditiveMonoid<T, TOperator>
    where TOperator : IAddBinaryOperator
{
    static abstract T AdditiveIdentity { get; }
    
    static T IMonoid<T, TOperator>.Identity => T.AdditiveIdentity;
}