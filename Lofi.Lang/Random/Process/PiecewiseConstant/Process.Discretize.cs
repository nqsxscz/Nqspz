using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Discretize<T>(
        this IContinuousProcess<T> continuousProcess,
        IStoppingSequence stoppingSequence)
        where T : notnull
        => new DiscretizedPiecewiseConstantContinuousProcess<T>(
            continuousProcess,
            stoppingSequence);
}