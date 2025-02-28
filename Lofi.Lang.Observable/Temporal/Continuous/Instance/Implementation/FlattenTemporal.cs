using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;

internal sealed record FlattenTemporal<T>(
    ITemporal<IMaybe<T>> Operand) :
    IFlattenTemporal<T>
    where T : notnull;