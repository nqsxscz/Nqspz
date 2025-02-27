using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Zero<T>()
        where T : IAdditiveMonoid<T>
        => T.Zero
            .ToDiscreteTemporal();
}