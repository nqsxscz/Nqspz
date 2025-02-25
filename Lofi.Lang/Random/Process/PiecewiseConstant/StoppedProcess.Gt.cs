using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<bool> Gt<T>(
        this IStoppedProcess<T> left,
        IStoppedProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Gt);
    
    public static IStoppedProcess<bool> Gt<T>(
        this IStoppedProcess<T> left,
        IProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Gt);
    
    public static IStoppedProcess<bool> Gt<T>(
        this IProcess<T> left,
        IStoppedProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Gt);
}