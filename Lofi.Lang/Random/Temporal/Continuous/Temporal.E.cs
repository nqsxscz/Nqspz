using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> E<T>()
        where T : IRealFunctions<T>
        => T.E
            .ToTemporal();
}