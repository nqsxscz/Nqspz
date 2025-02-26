using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Correlated;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Correlated;

internal sealed record CorrelatedStochasticProcess<T>(
    IStochasticProcess<T> Operand,
    T Correlation)
    : ICorrelatedStochasticProcess<T>
    where T : IReal<T>;