using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<bool> Neq<T>(
        this IDiscreteTemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
    
    public static IDiscreteTemporal<bool> Neq<T>(
        this IDiscreteTemporal<T> left,
        ITemporal<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
    
    public static IDiscreteTemporal<bool> Neq<T>(
        this ITemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Neq);
}