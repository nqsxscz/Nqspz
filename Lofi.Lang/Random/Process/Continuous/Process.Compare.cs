using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<bool> Eq<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
    
    public static IProcess<bool> Neq<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
    
    public static IProcess<bool> Lt<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Lt);
    
    public static IProcess<bool> Gt<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Gt);
    
    public static IProcess<bool> Leq<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
    
    public static IProcess<bool> Geq<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Geq);
}