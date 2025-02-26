using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Flatten<T>(
        this IPiecewiseConstantContinuousProcess<IMaybe<T>> continuousProcess)
        where T : notnull
        => Continuous.Process
            .Flatten(continuousProcess)
            .Discretize(continuousProcess.StoppingSequence);
}