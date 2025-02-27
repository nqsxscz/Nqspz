using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.TypeConstructor;
using Lofi.Prelude.Control;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<int> Count(
        this IEventSet stoppingSequence)
        => stoppingSequence
            .Time()
            .Length<IDiscreteTemporal, DateTime>()
            .ToDiscreteTemporal();

    public static IDiscreteTemporal<int> Count<T>(
        this IDiscreteTemporal<T> temporal)
        where T : notnull
        => temporal
            .EventSet()
            .Count();
}