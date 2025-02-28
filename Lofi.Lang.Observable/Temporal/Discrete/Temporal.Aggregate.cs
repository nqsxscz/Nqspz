using Lofi.Lang.Observable.Event.Set;
using Lofi.Lang.Observable.Temporal.Continuous;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IMaybe<T> Aggregate<T>(this 
        IDiscreteTemporal<T> operand,
        DateTime t)
        where T : IMonoid<T>
        => operand
            .Aggregate(
                T.Identity, 
                T.Combine, 
                t);

    public static Func<DateTime, IMaybe<T>> 
        Aggregate<T>(this 
            IDiscreteTemporal<T> operand,
            T init,
            Func<T, T, T> accumulator)
        where T : notnull
        => t
            => operand
                .Aggregate(
                    init, 
                    accumulator, 
                    t);
    
    public static IMaybe<T> Aggregate<T>(this 
        IDiscreteTemporal<T> operand,
        T init,
        Func<T, T, T> accumulator,
        DateTime t)
        where T : notnull
        => operand
            .AggregateLeft(
                init, 
                accumulator,
                t);
    
    public static Func<DateTime, IMaybe<T2>> 
        AggregateRight<T1, T2>(this 
            IDiscreteTemporal<T1> operand,
            T2 init,
            Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => t
            => AggregateRight(
                operand, 
                init, 
                accumulator, 
                t);
    
    public static IMaybe<T2> 
        AggregateRight<T1, T2>(this 
            IDiscreteTemporal<T1> operand,
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
    
    public static Func<DateTime, IMaybe<T2>> 
        AggregateLeft<T1, T2>(this 
            IDiscreteTemporal<T1> operand,
            T2 init,
            Func<T2, T1, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => t
            => AggregateLeft(
                operand, 
                init, 
                accumulator, 
                t);
    
    public static IMaybe<T2> 
        AggregateLeft<T1, T2>(this 
            IDiscreteTemporal<T1> operand,
            T2 init,
            Func<T2, T1, T2> accumulator,
            DateTime t)
        where T1 : notnull
        where T2 : notnull
        => operand
            .EventSet()
            .Occurrences(t)
            .Aggregate(
                init.ToMaybe(),
                (x, s) =>
                    Maybe.Lift(accumulator)(
                        x,
                        operand.Observe(s)));
}