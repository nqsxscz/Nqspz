using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record OffsetContinuousProcess<T>(
    IContinuousProcess<T> Operand,
    TimeSpan Offset,
    Func<DateTime, TimeSpan, DateTime> Offsetter)
    : IOffsetContinuousProcess<T>
    where T : notnull;