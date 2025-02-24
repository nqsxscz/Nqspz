namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record LiftProcess<T1, T2, T3>(
    IProcess<T1> Left,
    IProcess<T2> Right,
    Func<T1, T2, T3> Combinator)
    : ILiftProcess<T1, T2, T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull;