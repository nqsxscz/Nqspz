using Algebra.Operators;

namespace Algebra.Groups.Multiplicative;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMultiplicativeGroup<T> 
    : IMultiplicativeMonoid<T>, IGroup<T, IMultiplyBinaryOperator>
    where T : IMultiplicativeGroup<T>;