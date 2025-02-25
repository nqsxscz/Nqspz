using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Divide<T>(
        this IStoppedProcess<T> left,
        IStoppedProcess<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
    
    public static IStoppedProcess<T> Divide<T>(
        this IStoppedProcess<T> left,
        IProcess<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
    
    public static IStoppedProcess<T> Divide<T>(
        this IProcess<T> left,
        IStoppedProcess<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
}