using Algebra.Groups;
using Algebra.Operators;

namespace Algebra.Lattices;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TMeetOperator"></typeparam>
public interface IMeetSemilattice<T, TMeetOperator>
    : ISemilattice<T, TMeetOperator>
    where T : IMeetSemilattice<T, TMeetOperator>
    where TMeetOperator : IMeetBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract T Meet(T left, T right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static T IIdempotentSemigroup<T, TMeetOperator>.IdemCombine(T left, T right)
        => T.Meet(left, right);
}