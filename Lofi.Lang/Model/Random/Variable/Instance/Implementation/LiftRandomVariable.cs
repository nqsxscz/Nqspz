using Lofi.Lang.Model.Random.Variable.Instance.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Implementation;

internal sealed record LiftRandomVariable<T1, T2, T3>(
    IRandomVariable<T1> Left,
    IRandomVariable<T2> Right,
    Func<T1, T2, T3> Combinator)
    : ILiftRandomVariable<T1, T2, T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull;