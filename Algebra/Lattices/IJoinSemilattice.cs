using Algebra.Groups;
using Algebra.Operators;

namespace Algebra.Lattices;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TJoinOperator"></typeparam>
public interface IJoinSemilattice<T, TJoinOperator>
    : ISemilattice<T, TJoinOperator>
    where T : IJoinSemilattice<T, TJoinOperator>
    where TJoinOperator : IJoinBinaryOperator
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static abstract T Join(T left, T right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    static T IIdempotentSemigroup<T, TJoinOperator>.IdemCombine(T left, T right)
        => T.Join(left, right);
}