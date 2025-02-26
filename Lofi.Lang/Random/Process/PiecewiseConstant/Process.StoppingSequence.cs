using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IStoppingSequence StoppingSequence<T>(
        this IPiecewiseConstantContinuousProcess<T> process)
        where T : notnull
        => process
            .Accept(
                ProcessVisitor
                    .StoppingSequence);
}