using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Select;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Select;

internal sealed record SelectStochasticProcess<T1, T2>(
    IStochasticProcess<T1> Operand,
    Func<T1, T2> Selector)
    : ISelectStochasticProcess<T1, T2>
    where T1 : notnull
    where T2 : notnull;