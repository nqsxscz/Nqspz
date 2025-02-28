using Lofi.Lang.Observable.Event.Single.Instance.Type;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Observable.Event.Single;

public static partial class Event
{
    public static Func<IEvent, bool>
        Occurred(DateTime t)
        => stoppingTime 
            => stoppingTime
                .Occurred(t);

    public static bool Occurred(this 
        IEvent @event,
        DateTime t)
        => @event
            .Occurrence(t)
            .IsNotEmpty();
}