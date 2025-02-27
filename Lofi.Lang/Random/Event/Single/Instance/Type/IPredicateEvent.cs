using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Event.Single.Instance.Type;

public interface IPredicateEvent
    : IEvent
{
    IDiscreteTemporal<bool> Predicate { get; }

    int Index { get; }
}