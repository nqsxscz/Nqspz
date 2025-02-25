using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Lang.Model.Random.Variable;
using Lofi.Lang.Model.Random.Variable.Instance.Type;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IRandomVariable<T> Aggregate<T>(
        this IStochasticProcess<T> operand,
        DateTime t)
        where T : IMonoid<T>
        => operand
            .Aggregate(
                T.Identity, 
                T.Combine, 
                t);

    public static Func<DateTime, IRandomVariable<T>> Aggregate<T>(
        this IStochasticProcess<T> operand,
        T init,
        Func<T, T, T> accumulator)
        where T : notnull
        => t
            => operand
                .Aggregate(
                    init, 
                    accumulator, 
                    t);

    public static IRandomVariable<T> Aggregate<T>(
        this IStochasticProcess<T> operand,
        T init,
        Func<T, T, T> accumulator,
        DateTime t)
        where T : notnull
        => operand
            .AggregateLeft(
                init, 
                accumulator, 
                t);
    
    public static Func<DateTime, IRandomVariable<T2>> AggregateRight<T1, T2>(
        this IStochasticProcess<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => t
            => operand
                .AggregateRight(
                    init, 
                    accumulator, 
                    t);
    
    public static IRandomVariable<T2> AggregateRight<T1, T2>(
        this IStochasticProcess<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator,
        DateTime t)
        where T1 : notnull
        where T2 : notnull
        => operand
            .AggregateLeft(
                init, 
                accumulator.Flip(), 
                t);

    public static Func<DateTime, IRandomVariable<T2>> AggregateLeft<T1, T2>(
        this IStochasticProcess<T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => t
            => operand
                .AggregateLeft(
                    init, 
                    accumulator, 
                    t);
    
    public static IRandomVariable<T2> AggregateLeft<T1, T2>(
        this IStochasticProcess<T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator,
        DateTime t)
        where T1 : notnull
        where T2 : notnull
        => operand
            .Times
            .AggregateLeft(
                init.ToRandomVariable(),
                (x, s) =>
                    RandomVariable
                        .Lift(
                            x, 
                            operand.At(s), 
                            accumulator));
}