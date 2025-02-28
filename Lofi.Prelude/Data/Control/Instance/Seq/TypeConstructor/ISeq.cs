using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Utils;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Control.Instance.Seq.TypeConstructor;

public interface ISeq :
    IMonad<ISeq>,
    IScannable<ISeq>,
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

    static ITypeConstructor<ISeq, T3> IApplicative<ISeq>.Lift<T1, T2, T3>(
        ITypeConstructor<ISeq, T1> left,
        ITypeConstructor<ISeq, T2> right,
        Func<T1, T2, T3> combinator)
        => left
            .ToSeq()
            .Zip(
                right.ToSeq(), 
                combinator)
            .ToSeq();
    
    static ITypeConstructor<ISeq, T2>
        IScannable<ISeq>.ScanRight<T1, T2>(
            ITypeConstructor<ISeq, T1> operand,
            T2 init,
            Func<T1, T2, T2> accumulator)
        => operand
            .ToSeq()
            .Enumerable
            .Select((_, i) => 
                operand
                    .ToSeq()
                    .Take(i + 1))
            .Select(ts => 
                ts.ToSeq()
                    .AggregateRight(
                        init, 
                        accumulator))
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
            TF.Pure(Control.Seq.Empty<T2>()),
            (x, ys) =>
                TF.Lift(
                    ys,
                    traverse(x),
                    Control.Seq.Append));
}