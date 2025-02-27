using Lofi.Lang.Random.Event.Set.Instance.Implementation;
using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Event.Single;
using Lofi.Lang.Random.Event.Single.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Event.Set;

public static partial class EventSet
{
    public static IEventSet Of(
        IEnumerable<IEvent> stoppingTimes)
        => new SequenceEventSet(stoppingTimes);

    public static IEventSet Of(
        IEnumerable<DateTime> dateTimes)
        => dateTimes
            .Select(Single.Event.Of)
            .ToEventSet();

    public static IEventSet Of(
        IDiscreteTemporal<bool> predicate)
        => Iota(1)
            .Select(predicate.ToEvent)
            .ToEventSet();

    private static IEnumerable<int> Iota(int start)
    {
        var n = start;
        for (;;)
            yield return n++;
        // ReSharper disable once IteratorNeverReturns
    }
}