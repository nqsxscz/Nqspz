using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> One<T>()
        where T : IMultiplicativeMonoid<T>
        => T.One
            .ToTemporal();
}