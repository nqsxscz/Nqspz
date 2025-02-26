using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<bool> Neq<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
    
    public static IPiecewiseConstantContinuousProcess<bool> Neq<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IContinuousProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
    
    public static IPiecewiseConstantContinuousProcess<bool> Neq<T>(
        this IContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
}