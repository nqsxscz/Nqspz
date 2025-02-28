using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Implementation;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Discretize<T>(this 
        ITemporal<T> temporal,
        IEventSet stoppingSequence)
        where T : notnull
        => new DiscretizedTemporal<T>(
            temporal,
            stoppingSequence);
}