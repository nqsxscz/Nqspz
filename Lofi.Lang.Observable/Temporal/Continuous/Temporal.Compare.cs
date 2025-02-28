using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<bool> Eq<T>(this 
        ITemporal<T> left, 
        ITemporal<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
    
    public static ITemporal<bool> Neq<T>(this 
        ITemporal<T> left, 
        ITemporal<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
    
    public static ITemporal<bool> Lt<T>(this 
        ITemporal<T> left, 
        ITemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Lt);
    
    public static ITemporal<bool> Gt<T>(this 
        ITemporal<T> left, 
        ITemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Gt);
    
    public static ITemporal<bool> Leq<T>(this 
        ITemporal<T> left, 
        ITemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
    
    public static ITemporal<bool> Geq<T>(this 
        ITemporal<T> left, 
        ITemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Geq);
}