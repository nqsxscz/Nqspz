using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<bool> Eq<T>(this 
        IDiscreteTemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
    
    public static IDiscreteTemporal<bool> Eq<T>(this 
        IDiscreteTemporal<T> left,
        ITemporal<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
    
    public static IDiscreteTemporal<bool> Eq<T>(this 
        ITemporal<T> left,
        IDiscreteTemporal<T> right)
        where T : notnull
        => Lift(
            left, 
            right, 
            Orderable.Eq);
}