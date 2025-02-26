using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Scan<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IMonoid<T>
        => operand
            .Scan(
                T.Identity, 
                T.Combine);

    public static IPiecewiseConstantContinuousProcess<T> Scan<T>(
        this IPiecewiseConstantContinuousProcess<T> operand,
        T init,
        Func<T, T, T> accumulator)
        where T : notnull
        => operand
            .ScanLeft(
                init, 
                accumulator);
    public static IPiecewiseConstantContinuousProcess<T2> ScanRight<T1, T2>(
        this IPiecewiseConstantContinuousProcess<T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .ScanLeft(
                init,
                accumulator.Flip());
    
    public static IPiecewiseConstantContinuousProcess<T2> ScanLeft<T1, T2>(
        this IPiecewiseConstantContinuousProcess<T1> operand,
        T2 init,
        Func<T2, T1, T2> accumulator)
        where T1 : notnull
        where T2 : notnull
        => operand
            .Time()
            .Select(
                operand
                    .AggregateLeft(
                        init, 
                        accumulator))
            .Flatten();
}