using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Event.Single.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set;

public static partial class EventSet
{
    public static IEventSet ToEventSet(
        this IEnumerable<IEvent> stoppingTimes)
        => Of(stoppingTimes);

    public static IEventSet ToEventSet(
        this IEnumerable<DateTime> dateTimes)
        => Of(dateTimes);

    public static IEventSet ToEventSet(
        this IDiscreteTemporal<bool> predicate)
        => Of(predicate);
}