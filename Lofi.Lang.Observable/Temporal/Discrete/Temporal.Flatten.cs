using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Flatten<T>(
        this IDiscreteTemporal<IMaybe<T>> process)
        where T : notnull
        => Continuous.Temporal
            .Flatten(process)
            .Discretize(
                process
                    .EventSet());
}