using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Implementation;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Discretize<T>(
        this ITemporal<T> temporal,
        IEventSet stoppingSequence)
        where T : notnull
        => new DiscretizedTemporal<T>(
            temporal,
            stoppingSequence);
}