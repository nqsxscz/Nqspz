using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;

public interface IWienerStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : IReal<T>;