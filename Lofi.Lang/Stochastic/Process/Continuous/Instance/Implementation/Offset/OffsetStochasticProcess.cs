using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Offset;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Offset;

internal sealed record OffsetStochasticProcess<T>(
    IStochasticProcess<T> Operand,
    Func<DateTime, DateTime> Offsetter)
    : IOffsetStochasticProcess<T>
    where T : notnull;