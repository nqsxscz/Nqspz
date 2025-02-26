using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record ConstantContinuousProcess<T>(T Value)
    : IConstantContinuousProcess<T>
    where T : notnull;