using Lofi.Lang.Observable.Event.Set.Instance.Implementation;
using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Event.Single;
using Lofi.Lang.Observable.Event.Single.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set;

public static partial class EventSet
{
    public static IEventSet Of(
        IEnumerable<IEvent> events)
        => new SequenceEventSet(events);

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