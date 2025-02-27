using Lofi.Lang.Trait;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Event.Single.Instance.Type;

public interface IEvent
    : IOccurrable<IEvent>
{
    static IMaybe<DateTime>
        IOccurrable<IEvent>.Occurrence(
            IEvent @event,
            DateTime t)
        => @event.Occurrence(t);
}