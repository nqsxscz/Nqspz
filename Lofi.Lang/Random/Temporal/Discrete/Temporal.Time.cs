using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<DateTime> Time()
        => Event.Set.EventSet
            .Empty
            .Time();
    
    public static IDiscreteTemporal<DateTime> Time(
        this IEventSet stoppingSequence)
        => Continuous.Temporal
            .Time
            .Discretize(stoppingSequence);

    public static IDiscreteTemporal<DateTime> Time<T>(
        this IDiscreteTemporal<T> process)
        where T : notnull
        => process
            .EventSet()
            .Time();
}