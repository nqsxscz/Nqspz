using Lofi.Lang.Observable.Event.Set;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T3> Lift<T1, T2, T3>(
        IDiscreteTemporal<T1> left,
        IDiscreteTemporal<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => Continuous.Temporal
            .Lift(
                left,
                right,
                combinator)
            .Discretize(
                left.EventSet()
                    .Union(
                        right.EventSet()));

    public static IDiscreteTemporal<T3> Lift<T1, T2, T3>(
        ITemporal<T1> left,
        IDiscreteTemporal<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => Lift(
            left.Discretize(
                right.EventSet()),
            right,
            combinator);

    public static IDiscreteTemporal<T3> Lift<T1, T2, T3>(
        IDiscreteTemporal<T1> left,
        ITemporal<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => Lift(
            left,
            right.Discretize(
                left.EventSet()),
            combinator);
}