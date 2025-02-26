using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Lift;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Lift;

internal sealed record LiftStochasticProcess<T1, T2, T3>(
    IStochasticProcess<T1> Left,
    IStochasticProcess<T2> Right,
    Func<T1, T2, T3> Combinator)
    : ILiftStochasticProcess<T1, T2, T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull;