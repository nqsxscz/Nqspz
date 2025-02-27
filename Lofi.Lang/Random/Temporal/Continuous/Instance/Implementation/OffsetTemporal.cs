using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Continuous.Instance.Implementation;

internal sealed record OffsetTemporal<T>(
    ITemporal<T> Operand,
    TimeSpan Offset,
    Func<DateTime, TimeSpan, DateTime> Offsetter)
    : IOffsetTemporal<T>
    where T : notnull;