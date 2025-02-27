using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Empty<T>()
        where T : notnull
        => Continuous.Temporal
            .Empty<T>()
            .Discretize(
                Event.Set.EventSet.Empty);
}