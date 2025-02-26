using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface IOffsetStoppedProcess<out T> :
    IStoppedProcess<T>
    where T : notnull
{
    IStoppedProcess<T> Operand { get; }

    int Offset { get; }

    IStoppingSequence IStoppedProcess<T>.StoppingSequence
        => Operand.StoppingSequence;
    
    ITypeConstructor<TC, T> IProcess<T>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}