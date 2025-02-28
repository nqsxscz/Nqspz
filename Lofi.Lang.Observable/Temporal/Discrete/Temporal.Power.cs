using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Power<T, TNatural>(this 
        IDiscreteTemporal<T> left,
        IDiscreteTemporal<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IDiscreteTemporal<T> Power<T, TNatural>(this 
        IDiscreteTemporal<T> left,
        ITemporal<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IDiscreteTemporal<T> Power<T, TNatural>(this 
        ITemporal<T> left,
        IDiscreteTemporal<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IDiscreteTemporal<T> Power<T>(this 
        IDiscreteTemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
    
    public static IDiscreteTemporal<T> Power<T>(this 
        IDiscreteTemporal<T> left,
        ITemporal<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
    
    public static IDiscreteTemporal<T> Power<T>(this 
        ITemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
}