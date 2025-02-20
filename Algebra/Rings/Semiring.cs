using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;
using Algebra.Operators;

namespace Algebra.Rings;

/// <summary>
/// 
/// </summary>
public static class Semiring
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TAddOperator"></typeparam>
    /// <typeparam name="TMultiplyOperator"></typeparam>
    /// <returns></returns>
    public static T Multiply<T, TAddOperator, TMultiplyOperator>(this T left, T right)
        where T :
        ISemiring<T, TAddOperator, TMultiplyOperator>,
        IAdditiveMonoid<T, TAddOperator>,
        IMultiplicativeMonoid<T, TMultiplyOperator>
        where TAddOperator : IAddBinaryOperator
        where TMultiplyOperator : IMultiplyBinaryOperator
    {
        // The additive identity is a left and right annihilator for multiplication
        if (left.Equals(T.AdditiveIdentity) || right.Equals(T.AdditiveIdentity))
            return T.AdditiveIdentity;
        return T.Multiply(left, right);
    }
}