using Lofi.Lang.Observable.Event.Single.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Event.Single;

public static partial class Event
{
    public static IEvent ToEvent(
        this DateTime dt)
        => Of(dt);

    public static IEvent ToEvent(
        this IDiscreteTemporal<bool> predicate,
        int index = 1)
        => Of(
            predicate,
            index);
}