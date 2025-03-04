using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Differential;

internal sealed record WienerDifferentialStochasticProcess<T>(
    IWienerStochasticProcess<T> Operand)
    : IWienerDifferentialStochasticProcess<T>
    where T : IReal<T>;