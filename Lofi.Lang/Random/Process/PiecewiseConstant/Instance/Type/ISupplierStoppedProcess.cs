using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Lang.Random.Sequence;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface ISupplierStoppedProcess<out T> :
    IStoppedProcess<T>
    where T : notnull
{
    ISupplier<T> Supplier { get; }

    string Key { get; }

    IStoppingSequence IStoppedProcess<T>.StoppingSequence
        => Supplier
            .Times
            .ToStoppingSequence();
    
    ITypeConstructor<TC, T> IProcess<T>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}