using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Pi<T>()
        where T : IRealFunctions<T>
        => T.Pi
            .ToTemporal();
}