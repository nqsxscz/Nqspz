using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Power<T, TNatural>(
        this ITemporal<T> left, 
        ITemporal<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static ITemporal<T> Power<T>(
        this ITemporal<T> left, 
        ITemporal<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
}