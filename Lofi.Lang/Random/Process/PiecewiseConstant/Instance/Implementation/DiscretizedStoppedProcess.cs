using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record DiscretizedStoppedProcess<T>(
    IProcess<T> Operand,
    IStoppingSequence StoppingSequence) :
    IDiscretizedStoppedProcess<T>
    where T : notnull;