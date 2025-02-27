using Lofi.Lang.Observable.Event.Single.Instance.Implementation;
using Lofi.Lang.Observable.Event.Single.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Event.Single;

public static partial class Event
{
    public static IEvent Of(DateTime dt)
        => new ConstantEvent(dt);

    public static IEvent Of(
        IDiscreteTemporal<bool> predicate,
        int index = 1)
        => new PredicateEvent(
            predicate,
            index);
}