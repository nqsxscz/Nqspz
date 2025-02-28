using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Add<T>(this 
        IDiscreteTemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IAdditiveSemigroup<T>
        => Lift(
            left, 
            right, 
            Semigroup.Add);
    
    public static IDiscreteTemporal<T> Add<T>(this 
        IDiscreteTemporal<T> left,
        ITemporal<T> right)
        where T : IAdditiveSemigroup<T>
        => Lift(
            left, 
            right, 
            Semigroup.Add);
    
    public static IDiscreteTemporal<T> Add<T>(this 
        ITemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IAdditiveSemigroup<T>
        => Lift(
            left, 
            right, 
            Semigroup.Add);
}