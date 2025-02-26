using Lofi.Lang.Random.Process.PiecewiseConstant;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Process.Visitor.StoppingSequence.Type;

public interface IStoppingSequenceVisitor
    : IPiecewiseConstantProcessVisitor<IStoppingSequence>
{
    IStoppingSequence
        IPiecewiseConstantProcessVisitor<IStoppingSequence>.Visit<T>(
            IDiscretizedPiecewiseConstantContinuousProcess<T> process)
        => process
            .StoppingSequence;

    IStoppingSequence
        IPiecewiseConstantProcessVisitor<IStoppingSequence>.Visit<T>(
            IOffsetPiecewiseConstantContinuousProcess<T> process)
        => process
            .Operand
            .StoppingSequence();

    IStoppingSequence
        IPiecewiseConstantProcessVisitor<IStoppingSequence>.Visit<T>(
            ISupplierPiecewiseConstantContinuousProcess<T> process)
        => process
            .Supplier
            .Times
            .ToStoppingSequence();
}