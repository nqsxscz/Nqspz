using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Empty<T>()
        where T : notnull
        => Continuous.Process
            .Empty<T>()
            .Discretize(
                Sequence.StoppingSequence.Empty);
}