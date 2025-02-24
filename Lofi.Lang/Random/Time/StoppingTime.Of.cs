using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;
using Lofi.Lang.Random.Time.Instance;
using Lofi.Lang.Random.Time.Instance.Implementation;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    public static IStoppingTime Of(DateTime dt)
        => new ConstantStoppingTime(dt);

    public static IStoppingTime Of(
        IStoppedProcess<bool> predicate,
        int index = 1)
        => new PredicateStoppingTime(
            predicate,
            index);
}