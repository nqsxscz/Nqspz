using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Discretize<T>(
        this IProcess<T> process,
        IStoppingSequence stoppingSequence)
        where T : notnull
        => new DiscretizedStoppedProcess<T>(
            process,
            stoppingSequence);
}