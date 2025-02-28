using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Subtract<T>(this 
        ITemporal<T> left, 
        ITemporal<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
}