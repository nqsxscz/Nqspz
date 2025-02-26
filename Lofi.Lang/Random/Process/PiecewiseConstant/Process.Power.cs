using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Power<T, TNatural>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IPiecewiseConstantContinuousProcess<T> Power<T, TNatural>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IContinuousProcess<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IPiecewiseConstantContinuousProcess<T> Power<T, TNatural>(
        this IContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IPiecewiseConstantContinuousProcess<T> Power<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
    
    public static IPiecewiseConstantContinuousProcess<T> Power<T>(
        this IPiecewiseConstantContinuousProcess<T> left,
        IContinuousProcess<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
    
    public static IPiecewiseConstantContinuousProcess<T> Power<T>(
        this IContinuousProcess<T> left,
        IPiecewiseConstantContinuousProcess<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
}