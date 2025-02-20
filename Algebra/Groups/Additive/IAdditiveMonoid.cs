using Algebra.Operators;

namespace Algebra.Groups.Additive;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface IAdditiveMonoid<T, TOperator> 
    : IAdditiveSemigroup<T, TOperator>, IMonoid<T, TOperator>
    where T : IAdditiveMonoid<T, TOperator>
    where TOperator : IAddBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    static abstract T AdditiveIdentity { get; }
    
    /// <summary>
    /// 
    /// </summary>
    static T IMonoid<T, TOperator>.Identity => T.AdditiveIdentity;
}