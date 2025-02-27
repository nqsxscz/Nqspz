using Lofi.Lang.Observable.Event.Single.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Event.Single.Instance.Implementation;

internal sealed record PredicateEvent(
    IDiscreteTemporal<bool> Predicate,
    int Index)
    : IPredicateEvent;