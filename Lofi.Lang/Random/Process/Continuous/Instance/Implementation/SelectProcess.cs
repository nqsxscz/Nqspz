namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record SelectProcess<T1, T2>(
    IProcess<T1> Operand,
    Func<T1, T2> Selector)
    : ISelectProcess<T1, T2>
    where T1 : notnull
    where T2 : notnull;