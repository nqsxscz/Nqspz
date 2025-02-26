using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

internal sealed record SelectContinuousProcess<T1, T2>(
    IContinuousProcess<T1> Operand,
    Func<T1, T2> Selector)
    : ISelectContinuousProcess<T1, T2>
    where T1 : notnull
    where T2 : notnull;