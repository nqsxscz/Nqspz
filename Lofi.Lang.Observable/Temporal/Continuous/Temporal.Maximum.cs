using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Maximum<T>(
        this ITemporal<T> left, 
        ITemporal<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Maximum);
}