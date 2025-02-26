using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record OffsetPiecewiseConstantStochasticProcess<T>(
    IPiecewiseConstantStochasticProcess<T> Operand,
    int Offset)
    : IOffsetPiecewiseConstantStochasticProcess<T>
    where T : notnull;