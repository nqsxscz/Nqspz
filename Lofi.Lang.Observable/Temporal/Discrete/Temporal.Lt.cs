using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<bool> Lt<T>(this 
        IDiscreteTemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Lt);
    
    public static IDiscreteTemporal<bool> Lt<T>(this 
        IDiscreteTemporal<T> left,
        ITemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Lt);
    
    public static IDiscreteTemporal<bool> Lt<T>(this 
        ITemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Lt);
}