using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record FlattenProcess<T>(
    IProcess<IMaybe<T>> Operand) :
    IFlattenProcess<T>
    where T : notnull;