using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<bool> Eq<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
    
    public static IContinuousProcess<bool> Neq<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
    
    public static IContinuousProcess<bool> Lt<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Lt);
    
    public static IContinuousProcess<bool> Gt<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Gt);
    
    public static IContinuousProcess<bool> Leq<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
    
    public static IContinuousProcess<bool> Geq<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Geq);
}