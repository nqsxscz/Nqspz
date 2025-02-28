using Lofi.Lang.Observable.Event.Set.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set;

public static partial class EventSet
{
    public static bool
        Occurred(this 
            IEventSet sequence,
            DateTime t)
        => sequence
            .Occurrences(t)
            .Any();
}