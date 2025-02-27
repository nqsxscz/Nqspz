using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Divide<T>(
        this ITemporal<T> left, 
        ITemporal<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
}