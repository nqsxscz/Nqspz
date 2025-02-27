using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T2> Select<T1, T2>(
        this IDiscreteTemporal<T1> operand,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => Continuous.Temporal
            .Select(
                operand,
                selector)
            .Discretize(
                operand
                    .EventSet());
}