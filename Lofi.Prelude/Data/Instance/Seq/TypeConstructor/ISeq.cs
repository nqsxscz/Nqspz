using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Instance.Seq.TypeConstructor;

public interface ISeq :
    IMonad<ISeq>,
    ITraversable<ISeq>
{
    static ITypeConstructor<ISeq, T>
        IMonad<ISeq>.Return<T>(T item)
        => Data.Seq.Of(item);

    static ITypeConstructor<ISeq, T2>
        IMonad<ISeq>.SelectMany<T1, T2>(
            ITypeConstructor<ISeq, T1> seq,
            Func<T1, ITypeConstructor<ISeq, T2>> selector)
        => seq.ToSeq()
            .Enumerable
            .SelectMany(t1 =>
                selector(t1)
                    .ToSeq()
                    .Enumerable)
            .ToSeq();

    static T2 IFoldable<ISeq>.AggregateRight<T1, T2>(
        ITypeConstructor<ISeq, T1> seq,
        T2 init,
        Func<T1, T2, T2> aggregator)
        => seq.ToSeq()
            .Aggregate(
                init,
                aggregator.Flip());

    static ITypeConstructor<TF, ITypeConstructor<ISeq, T2>>
        ITraversable<ISeq>.Traverse<TF, T1, T2>(
            ITypeConstructor<ISeq, T1> seq,
            Func<T1, ITypeConstructor<TF, T2>> f)
        => seq.AggregateRight(
            TF.Pure(Data.Seq.Empty<T2>()),
            (x, ys) =>
                TF.Lift(
                    ys,
                    f(x),
                    Data.Seq.Append));
}