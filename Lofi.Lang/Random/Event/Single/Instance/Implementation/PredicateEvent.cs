using Lofi.Lang.Random.Event.Single.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Event.Single.Instance.Implementation;

internal sealed record PredicateEvent(
    IDiscreteTemporal<bool> Predicate,
    int Index)
    : IPredicateEvent;