using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;
using Lofi.Lang.Random.Sequence.Instance;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<int> Count(
        this IStoppingSequence stoppingSequence)
        => stoppingSequence
            .Time()
            .ScanLeft(
                0,
                (i, _) => i + 1);

    public static IStoppedProcess<int> Count<T>(
        this IStoppedProcess<T> process)
        where T : notnull
        => process
            .StoppingSequence
            .Count();
}