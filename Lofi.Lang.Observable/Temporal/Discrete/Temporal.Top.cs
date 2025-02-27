using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Top<T>()
        where T : IToppable<T>
        => T.Top
            .ToDiscreteTemporal();
}