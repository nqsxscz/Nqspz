using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Minimum<T>(
        this IStoppedProcess<T> left,
        IStoppedProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Minimum);
    
    public static IStoppedProcess<T> Minimum<T>(
        this IStoppedProcess<T> left,
        IProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Minimum);
    
    public static IStoppedProcess<T> Minimum<T>(
        this IProcess<T> left,
        IStoppedProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Minimum);
}