using Lofi.Lang.Random.Process.Continuous.Instance;
using Lofi.Lang.Random.Sequence.Instance;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record DiscretizedStoppedProcess<T>(
    IProcess<T> Operand,
    IStoppingSequence StoppingSequence) :
    IDiscretizedStoppedProcess<T>
    where T : notnull;