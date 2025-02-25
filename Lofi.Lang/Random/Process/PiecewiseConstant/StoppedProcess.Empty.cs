using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Empty<T>()
        where T : notnull
        => Continuous.Process
            .Empty<T>()
            .Discretize(
                StoppingSequence.Empty);
}