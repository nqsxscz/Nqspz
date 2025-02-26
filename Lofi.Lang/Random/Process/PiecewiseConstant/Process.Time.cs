using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<DateTime> Time()
        => StoppingSequence
            .Empty
            .Time();
    
    public static IPiecewiseConstantContinuousProcess<DateTime> Time(
        this IStoppingSequence stoppingSequence)
        => Continuous.Process
            .Time
            .Discretize(stoppingSequence);

    public static IPiecewiseConstantContinuousProcess<DateTime> Time<T>(
        this IPiecewiseConstantContinuousProcess<T> continuousProcess)
        where T : notnull
        => continuousProcess
            .StoppingSequence
            .Time();
}