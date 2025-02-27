using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;

internal sealed record LiftTemporal<T1, T2, T3>(
    ITemporal<T1> Left,
    ITemporal<T2> Right,
    Func<T1, T2, T3> Combinator)
    : ILiftTemporal<T1, T2, T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull;