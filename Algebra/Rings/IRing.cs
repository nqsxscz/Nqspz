using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;
using Algebra.Operators;

namespace Algebra.Rings;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TAddOperator"></typeparam>
/// <typeparam name="TMultiplyOperator"></typeparam>
public interface IRing<T, TAddOperator, TMultiplyOperator>
    : ISemiring<T, TAddOperator, TMultiplyOperator>
    where T : 
        IRing<T, TAddOperator, TMultiplyOperator>, 
        IAdditiveGroup<T, TAddOperator>, 
        IMultiplicativeMonoid<T, TMultiplyOperator>
    where TAddOperator : IAddBinaryOperator
    where TMultiplyOperator : IMultiplyBinaryOperator;