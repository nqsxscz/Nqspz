using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Flatten<T>(
        this IPiecewiseConstantContinuousProcess<IMaybe<T>> process)
        where T : notnull
        => Continuous.Process
            .Flatten(process)
            .Discretize(
                process
                    .StoppingSequence());
}