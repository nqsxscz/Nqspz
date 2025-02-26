using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Offset<T>(
        this IPiecewiseConstantContinuousProcess<T> continuousProcess,
        int offset)
        where T : notnull
        => new OffsetPiecewiseConstantContinuousProcess<T>(
            continuousProcess,
            offset);
}