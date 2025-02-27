using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Event.Single.Instance.Type;

namespace Lofi.Lang.Random.Event.Set.Instance.Implementation;

internal sealed record SequenceEventSet(
    IEnumerable<IEvent> StoppingTimes)
    : ISequenceEventSet;