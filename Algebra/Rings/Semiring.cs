using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;
using Algebra.Operators;

namespace Algebra.Rings;

public static class Semiring
{
    public static T Multiply<T, TAddOperator, TMultiplyOperator>(this T left, T right)
        where T :
        ISemiring<T, TAddOperator, TMultiplyOperator>,
        IAdditiveMonoid<T, TAddOperator>,
        IMultiplicativeMonoid<T, TMultiplyOperator>
        where TAddOperator : IAddBinaryOperator
        where TMultiplyOperator : IMultiplyBinaryOperator
    {
        if (left.Equals(T.AdditiveIdentity) || right.Equals(T.AdditiveIdentity))
            return T.AdditiveIdentity;
        return T.Multiply(left, right);
    }
}