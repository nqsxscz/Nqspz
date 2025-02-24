using Lofi.Prelude.Data.Instance.Maybe;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record FlattenProcess<T>(
    IProcess<IMaybe<T>> Operand) :
    IFlattenProcess<T>
    where T : notnull;