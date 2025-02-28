using Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Flatten<T>(
        this ITemporal<IMaybe<T>> temporal)
        where T : notnull
        => new FlattenTemporal<T>(temporal);
}