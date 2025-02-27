using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<int> Count(
        this IEventSet stoppingSequence)
        => stoppingSequence
            .Time()
            .ScanLeft(
                0,
                (i, _) => i + 1);

    public static IDiscreteTemporal<int> Count<T>(
        this IDiscreteTemporal<T> temporal)
        where T : notnull
        => temporal
            .EventSet()
            .Count();
}