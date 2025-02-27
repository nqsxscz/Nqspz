using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<bool> Leq<T>(
        this IDiscreteTemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
    
    public static IDiscreteTemporal<bool> Leq<T>(
        this IDiscreteTemporal<T> left,
        ITemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
    
    public static IDiscreteTemporal<bool> Leq<T>(
        this ITemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Leq);
}