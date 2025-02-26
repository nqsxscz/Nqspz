using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Divide<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
    
    public static IPiecewiseConstantContinuousProcess<T> Divide<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IContinuousProcess<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
    
    public static IPiecewiseConstantContinuousProcess<T> Divide<T>(
        this IContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
}