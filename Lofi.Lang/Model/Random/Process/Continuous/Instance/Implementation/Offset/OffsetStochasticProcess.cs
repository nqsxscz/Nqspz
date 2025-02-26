using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Offset;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Offset;

internal sealed record OffsetStochasticProcess<T>(
    IStochasticProcess<T> Operand,
    TimeSpan Offset,
    Func<DateTime, TimeSpan, DateTime> Offsetter)
    : IOffsetStochasticProcess<T>
    where T : notnull;