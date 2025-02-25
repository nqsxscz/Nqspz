using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Flatten<T>(
        this IStoppedProcess<IMaybe<T>> process)
        where T : notnull
        => Continuous.Process
            .Flatten(process)
            .Discretize(process.StoppingSequence);
}