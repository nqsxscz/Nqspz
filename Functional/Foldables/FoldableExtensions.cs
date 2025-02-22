using System.Numerics;

using Algebra.Groups;
using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;
using Algebra.Operators;

using Functional.HigherKindedTypes;

namespace Functional.Foldables;

/// <summary>
/// 
/// </summary>
public static class FoldableExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="init"></param>
    /// <param name="f"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static T2 AggregateRight<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        T2 init,
        Func<T1, T2, T2> f)
        where TC : IFoldable<TC>
        => TC.AggregateRight(input, init, f);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="init"></param>
    /// <param name="f"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    public static T2 AggregateLeft<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        T2 init,
        Func<T2, T1, T2> f)
        where TC : IFoldable<TC>
        => TC.AggregateRight(
            input, 
            init, 
            (t1, t2) => f(t2, t1));
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TOperator"></typeparam>
    /// <returns></returns>
    public static T Aggregate<TC, T, TOperator>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IMonoid<T, TOperator>
        where TOperator : IBinaryOperator
        => input.AggregateRight(T.Identity, T.Combine);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="f"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TM"></typeparam>
    /// <typeparam name="TOperator"></typeparam>
    /// <returns></returns>
    public static TM AggregateMap<TC, T, TM, TOperator>(
        this ITypeConstructor<TC, T> input,
        Func<T, TM> f)
        where TC : IFoldable<TC>
        where TM : IMonoid<TM, TOperator>
        where TOperator : IBinaryOperator
        => input.AggregateRight(
            TM.Identity, 
            (t, m) => 
                TM.Combine(f(t), m));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> Enumerate<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        => input.AggregateRight(
            Enumerable.Empty<T>(), 
            (t, ts) => ts.Append(t));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsEmpty<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        => input.AggregateRight(
            true, 
            (_, _) => true);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static int Length<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        => input.AggregateRight(
            0, 
            (_, i) => i + 1);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="item"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool Contains<TC, T>(
        this ITypeConstructor<TC, T> input,
        T item)
        where TC : IFoldable<TC>
        where T : IEquatable<T>
        => input.AggregateRight(
            false, 
            (t, found) => found || t.Equals(item));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Min<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IMinMaxValue<T>, IComparable<T>
        => input.AggregateRight(
            T.MinValue, 
            (t, min) => 
                t.CompareTo(min) < 0 ? t : min);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Max<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IMinMaxValue<T>, IComparable<T>
        => input.AggregateRight(
            T.MaxValue, 
            (t, max) => 
                t.CompareTo(max) > 0 ? t : max);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Sum<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IAdditiveMonoid<T>
        => input.AggregateRight(
            T.Zero, 
            AdditiveSemigroup.Add);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Product<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IMultiplicativeMonoid<T>
        => input.AggregateRight(
            T.One, 
            MultiplicativeSemigroup.Multiply);
}