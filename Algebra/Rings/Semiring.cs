using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;

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
    /// <returns></returns>
    public static T Multiply<T>(this T left, T right)
        where T :
        ISemiring<T>,
        IAdditiveMonoid<T>,
        IMultiplicativeMonoid<T>
    {
        // The additive identity is a left and right annihilator for multiplication
        if (left.Equals(T.Zero) || right.Equals(T.Zero))
            return T.Zero;
        return left * right;
    }
}