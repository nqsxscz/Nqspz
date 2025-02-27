using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Pi<T>()
        where T : IRealFunctions<T>
        => T.Pi
            .ToDiscreteTemporal();
}