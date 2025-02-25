using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence.Instance.Implementation;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Lang.Random.Time;
using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IStoppingSequence Of(
        IEnumerable<IStoppingTime> stoppingTimes)
        => new StoppingTimesSequence(stoppingTimes);

    public static IStoppingSequence Of(
        IEnumerable<DateTime> dateTimes)
        => dateTimes
            .Select(StoppingTime.Of)
            .ToStoppingSequence();

    public static IStoppingSequence Of(
        IStoppedProcess<bool> predicate)
        => Iota(1)
            .Select(predicate.ToStoppingTime)
            .ToStoppingSequence();

    private static IEnumerable<int> Iota(int start)
    {
        var n = start;
        for (;;)
            yield return n++;
        // ReSharper disable once IteratorNeverReturns
    }
}