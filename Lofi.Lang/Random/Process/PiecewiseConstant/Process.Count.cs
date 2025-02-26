using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<int> Count(
        this IStoppingSequence stoppingSequence)
        => stoppingSequence
            .Time()
            .ScanLeft(
                0,
                (i, _) => i + 1);

    public static IPiecewiseConstantContinuousProcess<int> Count<T>(
        this IPiecewiseConstantContinuousProcess<T> continuousProcess)
        where T : notnull
        => continuousProcess
            .StoppingSequence
            .Count();
}