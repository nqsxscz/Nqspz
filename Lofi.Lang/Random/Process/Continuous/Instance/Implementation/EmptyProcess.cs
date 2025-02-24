namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record EmptyProcess<T>
    : IEmptyProcess<T>
    where T : notnull;