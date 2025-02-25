using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Offset<T>(
        this IStoppedProcess<T> process,
        int offset)
        where T : notnull
        => new OffsetStoppedProcess<T>(
            process,
            offset);
}