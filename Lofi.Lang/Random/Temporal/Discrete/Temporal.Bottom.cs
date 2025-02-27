using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Bottom<T>()
        where T : IBottomable<T>
        => T.Bottom
            .ToDiscreteTemporal();
}