using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record FlattenContinuousProcess<T>(
    IContinuousProcess<IMaybe<T>> Operand) :
    IFlattenContinuousProcess<T>
    where T : notnull;