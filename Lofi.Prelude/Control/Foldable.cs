using System.Numerics;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

/// <summary>
/// </summary>
public static class Foldable
{
    /// <summary>
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
        where T1 : notnull
        where T2 : notnull
    {
        return TC.AggregateRight(input, init, f);
    }

    /// <summary>
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
        where T1 : notnull
        where T2 : notnull
    {
        return TC.AggregateRight(
            input,
            init,
            (t1, t2) => f(t2, t1));
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Aggregate<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IMonoid<T>
    {
        return input.AggregateRight(
            T.Identity,
            T.Combine);
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <param name="f"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TM"></typeparam>
    /// <returns></returns>
    public static TM AggregateMap<TC, TM, T>(
        this ITypeConstructor<TC, T> input,
        Func<T, TM> f)
        where TC : IFoldable<TC>
        where TM : IMonoid<TM>
        where T : notnull
    {
        return input.AggregateRight(
            TM.Identity,
            (t, m) =>
                TM.Combine(f(t), m));
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static ISeq<T> Enumerate<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull
    {
        return input.AggregateRight(
            Seq.Empty<T>(),
            (t, ts) => ts.Append(t));
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool IsEmpty<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull
    {
        return input.AggregateRight(
            true,
            (_, _) => true);
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static int Length<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull
    {
        return input.AggregateRight(
            0,
            (_, i) => i + 1);
    }

    /// <summary>
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
        where T : notnull
    {
        return input.AggregateRight(
            false,
            (t, found) => found || t.Equals(item));
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Min<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull, IMinMaxValue<T>, IComparable<T>
    {
        return input.AggregateRight(
            T.MinValue,
            (t, min) =>
                t.CompareTo(min) < 0 ? t : min);
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Max<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull, IMinMaxValue<T>, IComparable<T>
    {
        return input.AggregateRight(
            T.MaxValue,
            (t, max) =>
                t.CompareTo(max) > 0 ? t : max);
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Sum<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IAdditiveMonoid<T>
    {
        return input.AggregateRight(
            T.Zero,
            AdditiveSemigroup.Add);
    }

    /// <summary>
    /// </summary>
    /// <param name="input"></param>
    /// <typeparam name="TC"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Product<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IMultiplicativeMonoid<T>
    {
        return input.AggregateRight(
            T.One,
            MultiplicativeSemigroup.Multiply);
    }
}