using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Ito;

internal sealed record ItoStochasticProcess<T>(
    T Init,
    Func<T, T, T> Drift,
    Func<T, T, T> Volatility,
    Func<TimeSpan, T> Converter,
    IStochasticProcess<T> Left,
    IStochasticProcess<T> Right,
    IWienerStochasticProcess<T> Wiener)
    : IItoStochasticProcess<T>
    where T : 
        IReal<T>;