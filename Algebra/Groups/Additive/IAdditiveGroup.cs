using Algebra.Operators;

namespace Algebra.Groups.Additive;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAdditiveGroup<T> 
    : IAdditiveMonoid<T>, IGroup<T, IAddBinaryOperator>
    where T : IAdditiveGroup<T>;