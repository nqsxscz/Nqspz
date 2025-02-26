using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    public static IStoppingTime ToStoppingTime(
        this DateTime dt)
        => Of(dt);

    public static IStoppingTime ToStoppingTime(
        this IPiecewiseConstantContinuousProcess<bool> predicate,
        int index = 1)
        => Of(
            predicate,
            index);
}