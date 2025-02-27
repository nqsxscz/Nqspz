using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> One<T>()
        where T : IMultiplicativeMonoid<T>
        => T.One
            .ToDiscreteTemporal();
}