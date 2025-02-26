using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface IOffsetPiecewiseConstantContinuousProcess<out T> :
    IPiecewiseConstantContinuousProcess<T>
    where T : notnull
{
    IPiecewiseConstantContinuousProcess<T> Operand { get; }

    int Offset { get; }

    IStoppingSequence IPiecewiseConstantContinuousProcess<T>.StoppingSequence
        => Operand.StoppingSequence;
    
    ITypeConstructor<TC, T> IContinuousProcess<T>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}