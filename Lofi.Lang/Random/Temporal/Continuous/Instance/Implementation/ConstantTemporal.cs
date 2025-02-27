using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Continuous.Instance.Implementation;

internal sealed record ConstantTemporal<T>(T Value)
    : IConstantTemporal<T>
    where T : notnull;