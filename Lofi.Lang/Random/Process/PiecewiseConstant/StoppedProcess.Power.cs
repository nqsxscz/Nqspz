using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Power<T, TNatural>(
        this IStoppedProcess<T> left,
        IStoppedProcess<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IStoppedProcess<T> Power<T, TNatural>(
        this IStoppedProcess<T> left,
        IProcess<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IStoppedProcess<T> Power<T, TNatural>(
        this IProcess<T> left,
        IStoppedProcess<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IStoppedProcess<T> Power<T>(
        this IStoppedProcess<T> left,
        IStoppedProcess<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
    
    public static IStoppedProcess<T> Power<T>(
        this IStoppedProcess<T> left,
        IProcess<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
    
    public static IStoppedProcess<T> Power<T>(
        this IProcess<T> left,
        IStoppedProcess<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
}