using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record OffsetStoppedProcess<T>(
    IStoppedProcess<T> Operand,
    int Offset) :
    IOffsetStoppedProcess<T>
    where T : notnull;