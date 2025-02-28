using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T2> ScanRight<T1, T2>(this 
        IDiscreteTemporal<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .Time()
            .Select(
                operand
                    .AggregateRight(
                        init, 
                        accumulator))
            .Flatten();
}