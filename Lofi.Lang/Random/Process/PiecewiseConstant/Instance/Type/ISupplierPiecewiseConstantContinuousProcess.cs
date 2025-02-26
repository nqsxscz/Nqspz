using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Lang.Random.Sequence;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface ISupplierPiecewiseConstantContinuousProcess<out T> :
    IPiecewiseConstantContinuousProcess<T>
    where T : notnull
{
    ISupplier<T> Supplier { get; }

    string Key { get; }

    IStoppingSequence IPiecewiseConstantContinuousProcess<T>.StoppingSequence
        => Supplier
            .Times
            .ToStoppingSequence();
    
    ITypeConstructor<TC, T> IContinuousProcess<T>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}