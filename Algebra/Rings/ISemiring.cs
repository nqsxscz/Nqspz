using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;
using Algebra.Operators;

namespace Algebra.Rings;

public interface ISemiring<T, TAddOperator, TMultiplyOperator>
    where T :
        ISemiring<T, TAddOperator, TMultiplyOperator>,
        IAdditiveMonoid<T, TAddOperator>,
        IMultiplicativeMonoid<T, TMultiplyOperator>
    where TAddOperator : IAddBinaryOperator
    where TMultiplyOperator : IMultiplyBinaryOperator;