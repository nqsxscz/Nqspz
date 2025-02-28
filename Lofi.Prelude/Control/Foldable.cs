using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

public static class Foldable
{
    public static T2 AggregateRight<TC, T1, T2>(
        this ITypeConstructor<TC, T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where TC : IFoldable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.AggregateRight(
            operand, 
            init, 
            accumulator);

    public static T2 AggregateLeft<TC, T1, T2>(
        this ITypeConstructor<TC, T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator)
        where TC : IFoldable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.AggregateRight(
            operand,
            init,
            accumulator.Flip());

    public static T Aggregate<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : IMonoid<T>
        => operand.AggregateRight(
            T.Identity,
            T.Combine);

    public static TM AggregateSelect<TC, TM, T>(
        this ITypeConstructor<TC, T> operand,
        Func<T, TM> selector)
        where TC : IFoldable<TC>
        where TM : IMonoid<TM>
        where T : notnull
        => operand.AggregateRight(
            TM.Identity,
            (t, m) =>
                TM.Combine(selector(t), m));

    public static ISeq<T> Enumerate<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.AggregateRight(
            Seq.Empty<T>(),
            (t, ts) => ts.Append(t));

    public static bool IsEmpty<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.AggregateRight(
            true,
            (_, _) => false);

    public static bool IsNotEmpty<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : notnull
        => !operand.IsEmpty();

    public static bool Any<TC, T>(
        this ITypeConstructor<TC, T> operand,
        Func<T, bool> predicate)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.AggregateRight(
            false,
            (t, p) => p || predicate(t));
    
    public static bool All<TC, T>(
        this ITypeConstructor<TC, T> operand,
        Func<T, bool> predicate)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.AggregateRight(
            true,
            (t, p) => p && predicate(t));

    public static bool Contains<TC, T>(
        this ITypeConstructor<TC, T> operand,
        T item)
        where TC : IFoldable<TC>
        where T : notnull
        => operand
            .Any(t => t.Equals(item));
    
    public static bool And<TC>(
        this ITypeConstructor<TC, bool> operand)
        where TC : IFoldable<TC>
        => operand.AggregateRight(
            true,
            (t, p) => p && t);
    
    public static bool Or<TC>(
        this ITypeConstructor<TC, bool> operand)
        where TC : IFoldable<TC>
        => operand.AggregateRight(
            false,
            (t, p) => p || t);
    
    public static int Length<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.AggregateRight(
            0,
            (_, i) => i + 1);

    public static T Minimum<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : 
            notnull, 
            IBottomable<T>, 
            IOrderable<T>
        => operand.AggregateRight(
            T.Bottom,
            T.Minimum);

    public static T Maximum<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : 
            notnull, 
            IToppable<T>, 
            IOrderable<T>
        => operand.AggregateRight(
            T.Top,
            T.Maximum);

    public static T Sum<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : IAdditiveMonoid<T>
        => operand.AggregateRight(
            T.Zero,
            Semigroup.Add);

    public static T Product<TC, T>(
        this ITypeConstructor<TC, T> operand)
        where TC : IFoldable<TC>
        where T : IMultiplicativeMonoid<T>
        => operand.AggregateRight(
            T.One,
            Semigroup.Multiply);
    
    public static IMaybe<T> Find<TC, T>(
        this ITypeConstructor<TC, T> operand,
        Func<T, bool> predicate)
        where TC : IFoldable<TC>
        where T : notnull
        => operand.AggregateRight(
            Maybe.Nothing<T>(),
            (t, p) => 
                p.OrElse(
                    predicate(t) ? 
                        t.ToMaybe() 
                        : Maybe.Nothing<T>()));
}