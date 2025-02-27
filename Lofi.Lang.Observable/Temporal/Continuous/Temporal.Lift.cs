using Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T3> Lift<T1, T2, T3>(
        ITemporal<T1> left,
        ITemporal<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => new LiftTemporal<T1, T2, T3>(
            left,
            right,
            combinator);
}