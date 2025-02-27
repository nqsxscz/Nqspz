using Lofi.Lang.Random.Event.Single.Instance.Type;

namespace Lofi.Lang.Random.Event.Set.Instance.Type;

public interface ISequenceEventSet
    : IEventSet
{
    IEnumerable<IEvent> StoppingTimes { get; }
}