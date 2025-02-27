using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Wiener;

internal sealed record CorrelatedWienerStochasticProcess<T>(
    IWienerStochasticProcess<T> Left,
    IWienerStochasticProcess<T> Right,
    T Correlation)
    : ICorrelatedWienerStochasticProcess<T>
    where T : IReal<T>;