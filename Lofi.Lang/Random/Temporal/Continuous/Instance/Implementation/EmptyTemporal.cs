using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Continuous.Instance.Implementation;

internal sealed record EmptyTemporal<T>
    : IEmptyTemporal<T>
    where T : notnull;