using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Add<T>(
        this IStoppedProcess<T> left,
        IStoppedProcess<T> right)
        where T : IAdditiveSemigroup<T>
        => Lift(
            left, 
            right, 
            Semigroup.Add);
    
    public static IStoppedProcess<T> Add<T>(
        this IStoppedProcess<T> left,
        IProcess<T> right)
        where T : IAdditiveSemigroup<T>
        => Lift(
            left, 
            right, 
            Semigroup.Add);
    
    public static IStoppedProcess<T> Add<T>(
        this IProcess<T> left,
        IStoppedProcess<T> right)
        where T : IAdditiveSemigroup<T>
        => Lift(
            left, 
            right, 
            Semigroup.Add);
}