using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T2> Select<T1, T2>(
        this IStoppedProcess<T1> operand,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => Continuous.Process
            .Select(
                operand,
                selector)
            .Discretize(operand.StoppingSequence);
}