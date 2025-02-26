using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record EmptyContinuousProcess<T>
    : IEmptyContinuousProcess<T>
    where T : notnull;