using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Event.Single.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Event.Set;

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