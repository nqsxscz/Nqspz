using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;
using Lofi.Lang.Random.Sequence.Instance;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<DateTime> Time(
        this IStoppingSequence stoppingSequence)
        => Continuous.Process
            .Time
            .Discretize(stoppingSequence);

    public static IStoppedProcess<DateTime> Time<T>(
        this IStoppedProcess<T> process)
        where T : notnull
        => process
            .StoppingSequence
            .Time();
}