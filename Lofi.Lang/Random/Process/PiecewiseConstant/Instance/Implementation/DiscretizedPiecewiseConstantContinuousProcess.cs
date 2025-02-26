using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record DiscretizedPiecewiseConstantContinuousProcess<T>(
    IContinuousProcess<T> Operand,
    IStoppingSequence StoppingSequence) :
    IDiscretizedPiecewiseConstantContinuousProcess<T>
    where T : notnull;