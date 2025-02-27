using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Bottom<T>()
        where T : IBottomable<T>
        => T.Bottom
            .ToTemporal();
}