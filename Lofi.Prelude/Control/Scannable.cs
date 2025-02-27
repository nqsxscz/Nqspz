using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

public static class Scannable
{ 
    public static ITypeConstructor<TC, T2> ScanRight<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        T2 init,
        Func<T1, T2, T2> f)
        where TC : IScannable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.ScanRight(input, init, f);

    public static ITypeConstructor<TC, T2> ScanLeft<TC, T1, T2>(
        this ITypeConstructor<TC, T1> input,
        T2 init,
        Func<T2, T1, T2> f)
        where TC : IScannable<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.ScanRight(
            input,
            init,
            f.Flip());

    public static ITypeConstructor<TC, T> Scan<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IScannable<TC>
        where T : IMonoid<T>
        => input.ScanRight(
            T.Identity,
            T.Combine);

    public static ITypeConstructor<TC, TM> ScanMap<TC, TM, T>(
        this ITypeConstructor<TC, T> input,
        Func<T, TM> f)
        where TC : IScannable<TC>
        where TM : IMonoid<TM>
        where T : notnull
        => input.ScanRight(
            TM.Identity,
            (t, m) =>
                TM.Combine(f(t), m));

    public static ITypeConstructor<TC, ISeq<T>> Enumerate<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IScannable<TC>
        where T : notnull
        => input.ScanRight(
            Seq.Empty<T>(),
            (t, ts) => ts.Append(t));

    public static ITypeConstructor<TC, bool> IsEmpty<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IScannable<TC>
        where T : notnull
        => input.ScanRight(
            true,
            (_, _) => true);

    public static ITypeConstructor<TC, int> Length<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IScannable<TC>
        where T : notnull
        => input.ScanRight(
            0,
            (_, i) => i + 1);

    public static ITypeConstructor<TC, bool> Contains<TC, T>(
        this ITypeConstructor<TC, T> input,
        T item)
        where TC : IScannable<TC>
        where T : notnull
        => input.ScanRight(
            false,
            (t, found) => found || t.Equals(item));

    public static ITypeConstructor<TC, T> Minimum<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IScannable<TC>
        where T : 
            notnull, 
            IBottomable<T>, 
            IOrderable<T>
        => input.ScanRight(
            T.Bottom,
            T.Minimum);

    public static ITypeConstructor<TC, T> Maximum<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IScannable<TC>
        where T : 
            notnull, 
            IToppable<T>, 
            IOrderable<T>
        => input.ScanRight(
            T.Top,
            T.Maximum);

    public static ITypeConstructor<TC, T> Sum<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IScannable<TC>
        where T : IAdditiveMonoid<T>
        => input.ScanRight(
            T.Zero,
            Semigroup.Add);

    public static ITypeConstructor<TC, T> Product<TC, T>(
        this ITypeConstructor<TC, T> input)
        where TC : IScannable<TC>
        where T : IMultiplicativeMonoid<T>
        => input.ScanRight(
            T.One,
            Semigroup.Multiply);
}