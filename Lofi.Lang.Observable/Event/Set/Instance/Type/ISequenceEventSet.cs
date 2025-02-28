using Lofi.Lang.Observable.Event.Single.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set.Instance.Type;

public interface ISequenceEventSet
    : IEventSet
{
    IEnumerable<IEvent> Events { get; }
}