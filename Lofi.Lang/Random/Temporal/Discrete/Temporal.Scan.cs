using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Scan<T>(
        this IDiscreteTemporal<T> operand)
        where T : IMonoid<T>
        => operand
            .Scan(
                T.Identity, 
                T.Combine);

    public static IDiscreteTemporal<T> Scan<T>(
        this IDiscreteTemporal<T> operand,
        T init,
        Func<T, T, T> accumulator)
        where T : notnull
        => operand
            .ScanLeft(
                init, 
                accumulator);
    public static IDiscreteTemporal<T2> ScanRight<T1, T2>(
        this IDiscreteTemporal<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .ScanLeft(
                init,
                accumulator.Flip());
    
    public static IDiscreteTemporal<T2> ScanLeft<T1, T2>(
        this IDiscreteTemporal<T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .Time()
            .Select(
                operand
                    .AggregateLeft(
                        init, 
                        accumulator))
            .Flatten();
}