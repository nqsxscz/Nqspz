using Algebra.Operators;

namespace Algebra.Groups.Additive;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAdditiveMonoid<T> 
    : IAdditiveSemigroup<T>, IMonoid<T, IAddBinaryOperator>
    where T : IAdditiveMonoid<T>
{
    /// <summary>
    /// 
    /// </summary>
    static abstract T Zero { get; }
    
    /// <summary>
    /// 
    /// </summary>
    static T IMonoid<T, IAddBinaryOperator>.Identity => T.Zero;
}