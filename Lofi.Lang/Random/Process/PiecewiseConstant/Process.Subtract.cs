using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Subtract<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
    
    public static IPiecewiseConstantContinuousProcess<T> Subtract<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IContinuousProcess<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
    
    public static IPiecewiseConstantContinuousProcess<T> Subtract<T>(
        this IContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
}