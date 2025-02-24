using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;
using Lofi.Lang.Random.Sequence.Instance;
using Lofi.Lang.Random.Time.Instance;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IStoppingSequence ToStoppingSequence(
        this IEnumerable<IStoppingTime> stoppingTimes)
        => Of(stoppingTimes);

    public static IStoppingSequence ToStoppingSequence(
        this IEnumerable<DateTime> dateTimes)
        => Of(dateTimes);

    public static IStoppingSequence ToStoppingSequence(
        this IStoppedProcess<bool> predicate)
        => Of(predicate);
}