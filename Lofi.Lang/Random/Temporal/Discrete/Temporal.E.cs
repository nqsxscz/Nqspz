using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> E<T>()
        where T : IRealFunctions<T>
        => T.E
            .ToDiscreteTemporal();
}