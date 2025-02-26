using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Time.Instance.Implementation;
using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    public static IStoppingTime Of(DateTime dt)
        => new ConstantStoppingTime(dt);

    public static IStoppingTime Of(
        IPiecewiseConstantContinuousProcess<bool> predicate,
        int index = 1)
        => new PredicateStoppingTime(
            predicate,
            index);
}