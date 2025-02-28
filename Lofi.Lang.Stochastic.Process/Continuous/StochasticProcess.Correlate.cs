using Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Wiener;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static ICorrelatedWienerStochasticProcess<T>
        Correlate<T>(this 
            IWienerStochasticProcess<T> wiener,
            T correlation)
        where T : IReal<T>
        => new CorrelatedWienerStochasticProcess<T>(
            wiener,
            correlation);
}