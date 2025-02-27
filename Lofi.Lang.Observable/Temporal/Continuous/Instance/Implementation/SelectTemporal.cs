using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;

internal sealed record SelectTemporal<T1, T2>(
    ITemporal<T1> Operand,
    Func<T1, T2> Selector)
    : ISelectTemporal<T1, T2>
    where T1 : notnull
    where T2 : notnull;