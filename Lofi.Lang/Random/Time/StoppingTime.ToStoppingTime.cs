using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;
using Lofi.Lang.Random.Time.Instance;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    public static IStoppingTime ToStoppingTime(
        this DateTime dt)
        => Of(dt);

    public static IStoppingTime ToStoppingTime(
        this IStoppedProcess<bool> predicate,
        int index = 1)
        => Of(
            predicate,
            index);
}