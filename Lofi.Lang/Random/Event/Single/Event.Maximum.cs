using Lofi.Lang.Random.Event.Single.Instance.Implementation;
using Lofi.Lang.Random.Event.Single.Instance.Type;

namespace Lofi.Lang.Random.Event.Single;

public static partial class Event
{
    private static IEvent Maximum(
        this IEvent left,
        IEvent right)
        => new MaximumEvent(
            left, 
            right);
}