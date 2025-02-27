using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Event.Single.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set.Instance.Implementation;

internal sealed record SequenceEventSet(
    IEnumerable<IEvent> StoppingTimes)
    : ISequenceEventSet;