using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;

internal sealed record EmptyTemporal<T>
    : IEmptyTemporal<T>
    where T : notnull;