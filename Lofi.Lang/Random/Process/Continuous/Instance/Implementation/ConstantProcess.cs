namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record ConstantProcess<T>(T Value)
    : IConstantProcess<T>
    where T : notnull;