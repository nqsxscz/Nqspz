using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

public static class Foldable
{
    public static T2 AggregateRight<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        T2 init,
        Func<T1, T2, T2> f)
        where TC : IFoldable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.AggregateRight(input, init, f);

    public static T2 AggregateLeft<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        T2 init,
        Func<T2, T1, T2> f)
        where TC : IFoldable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.AggregateRight(
            input,
            init,
            f.Flip());

    public static T Aggregate<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IMonoid<T>
        => input.AggregateRight(
            T.Identity,
            T.Combine);

    public static TM AggregateMap<TC, TM, T>(
        this ITypeConstructor<TC, T> input,
        Func<T, TM> f)
        where TC : IFoldable<TC>
        where TM : IMonoid<TM>
        where T : notnull
        => input.AggregateRight(
            TM.Identity,
            (t, m) =>
                TM.Combine(f(t), m));

    public static ISeq<T> Enumerate<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull
        => input.AggregateRight(
            Seq.Empty<T>(),
            (t, ts) => ts.Append(t));

    public static bool IsEmpty<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull
        => input.AggregateRight(
            true,
            (_, _) => true);

    public static int Length<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull
        => input.AggregateRight(
            0,
            (_, i) => i + 1);

    public static bool Contains<TC, T>(
        this ITypeConstructor<TC, T> input,
        T item)
        where TC : IFoldable<TC>
        where T : notnull
        => input.AggregateRight(
            false,
            (t, found) => found || t.Equals(item));

    public static T Minimum<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull, IBottomable<T>, IOrderable<T>
        => input.AggregateRight(
            T.Bottom,
            T.Minimum);

    public static T Maximum<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : notnull, IToppable<T>, IOrderable<T>
        => input.AggregateRight(
            T.Top,
            T.Maximum);

    public static T Sum<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IAdditiveMonoid<T>
        => input.AggregateRight(
            T.Zero,
            Semigroup.Add);

    public static T Product<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IFoldable<TC>
        where T : IMultiplicativeMonoid<T>
        => input.AggregateRight(
            T.One,
            Semigroup.Multiply);
}