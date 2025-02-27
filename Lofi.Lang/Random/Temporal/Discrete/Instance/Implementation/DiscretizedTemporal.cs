using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Discrete.Instance.Implementation;

internal sealed record DiscretizedTemporal<T>(
    ITemporal<T> Operand,
    IEventSet EventSet) :
    IDiscretizedTemporal<T>
    where T : notnull;