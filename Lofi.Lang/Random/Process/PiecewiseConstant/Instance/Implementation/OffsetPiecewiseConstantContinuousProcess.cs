using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record OffsetPiecewiseConstantContinuousProcess<T>(
    IPiecewiseConstantContinuousProcess<T> Operand,
    int Offset) :
    IOffsetPiecewiseConstantContinuousProcess<T>
    where T : notnull;