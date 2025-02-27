using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete.Instance.Implementation;

internal sealed record DiscretizedTemporal<T>(
    ITemporal<T> Operand,
    IEventSet EventSet) :
    IDiscretizedTemporal<T>
    where T : notnull;