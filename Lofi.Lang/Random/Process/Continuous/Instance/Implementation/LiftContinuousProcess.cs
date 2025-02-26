using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record LiftContinuousProcess<T1, T2, T3>(
    IContinuousProcess<T1> Left,
    IContinuousProcess<T2> Right,
    Func<T1, T2, T3> Combinator)
    : ILiftContinuousProcess<T1, T2, T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull;