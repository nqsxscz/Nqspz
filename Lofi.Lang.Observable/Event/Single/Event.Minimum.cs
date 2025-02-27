using Lofi.Lang.Observable.Event.Single.Instance.Implementation;
using Lofi.Lang.Observable.Event.Single.Instance.Type;

namespace Lofi.Lang.Observable.Event.Single;

public static partial class Event
{
    private static IEvent Minimum(
        this IEvent left,
        IEvent right)
        => new MinimumEvent(
            left,
            right);
}