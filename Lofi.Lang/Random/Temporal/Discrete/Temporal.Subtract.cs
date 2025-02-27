using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Subtract<T>(
        this IDiscreteTemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
    
    public static IDiscreteTemporal<T> Subtract<T>(
        this IDiscreteTemporal<T> left,
        ITemporal<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
    
    public static IDiscreteTemporal<T> Subtract<T>(
        this ITemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
}