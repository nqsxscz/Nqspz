using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<bool> Eq<T>(
        this IStoppedProcess<T> left,
        IStoppedProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
    
    public static IStoppedProcess<bool> Eq<T>(
        this IStoppedProcess<T> left,
        IProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
    
    public static IStoppedProcess<bool> Eq<T>(
        this IProcess<T> left,
        IStoppedProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
}