using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Instance.Seq.TypeConstructor;

public interface ISeq :
    IMonad<ISeq>,
    ITraversable<ISeq>
{
    static ITypeConstructor<ISeq, T>
        IMonad<ISeq>.Return<T>(T t)
        => t.ToSeq();

    static ITypeConstructor<ISeq, T2>
        IMonad<ISeq>.SelectMany<T1, T2>(
            ITypeConstructor<ISeq, T1> operand,
            Func<T1, ITypeConstructor<ISeq, T2>> selector)
        => operand.ToSeq()
            .Enumerable
            .SelectMany(t1 =>
                selector(t1)
                    .ToSeq()
                    .Enumerable)
            .ToSeq();

    static T2 IFoldable<ISeq>.AggregateRight<T1, T2>(
        ITypeConstructor<ISeq, T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        => operand.ToSeq()
            .Aggregate(
                init,
                accumulator.Flip());

    static ITypeConstructor<TF, ITypeConstructor<ISeq, T2>>
        ITraversable<ISeq>.Traverse<TF, T1, T2>(
            ITypeConstructor<ISeq, T1> operand,
            Func<T1, ITypeConstructor<TF, T2>> traverse)
        => operand.AggregateRight(
            TF.Pure(Data.Seq.Empty<T2>()),
            (x, ys) =>
                TF.Lift(
                    ys,
                    traverse(x),
                    Data.Seq.Append));
}