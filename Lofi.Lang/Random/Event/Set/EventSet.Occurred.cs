using Lofi.Lang.Random.Event.Set.Instance.Type;

namespace Lofi.Lang.Random.Event.Set;

public static partial class EventSet
{
    public static bool
        Occurred(
            this IEventSet sequence,
            DateTime t)
        => sequence
            .Occurrences(t)
            .Any();
}