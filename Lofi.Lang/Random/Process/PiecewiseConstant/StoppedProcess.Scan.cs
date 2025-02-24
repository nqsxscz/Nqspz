using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;
using Lofi.Lang.Random.Sequence;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T2> ScanLeft<T1, T2>(
        this IStoppedProcess<T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .Time()
            .Select(t =>
                operand
                    .StoppingSequence
                    .Occurrences(t)
                    .Aggregate(
                        init.ToMaybe(),
                        (x, s) =>
                            Maybe.Lift(accumulator)(
                                x,
                                operand.Observe(s))))
            .Flatten();

    public static IStoppedProcess<T2> ScanRight<T1, T2>(
        this IStoppedProcess<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .ScanLeft(
                init,
                accumulator.Flip());
}