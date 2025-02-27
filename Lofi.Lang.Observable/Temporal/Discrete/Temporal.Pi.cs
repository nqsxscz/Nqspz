using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Pi<T>()
        where T : IReal<T>
        => T.Pi
            .ToDiscreteTemporal();
}