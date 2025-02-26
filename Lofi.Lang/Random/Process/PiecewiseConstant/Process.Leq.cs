using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<bool> Leq<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
    
    public static IPiecewiseConstantContinuousProcess<bool> Leq<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IContinuousProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
    
    public static IPiecewiseConstantContinuousProcess<bool> Leq<T>(
        this IContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
}