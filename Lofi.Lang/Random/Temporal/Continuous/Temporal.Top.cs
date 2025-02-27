using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Top<T>()
        where T : IToppable<T>
        => T.Top
            .ToTemporal();
}