using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Wiener;

internal sealed record WienerStochasticProcess<T>
    : IWienerStochasticProcess<T>
    where T : IReal<T>;