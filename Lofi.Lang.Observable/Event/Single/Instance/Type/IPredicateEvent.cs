using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Event.Single.Instance.Type;

public interface IPredicateEvent
    : IEvent
{
    IDiscreteTemporal<bool> Predicate { get; }

    int Index { get; }
}