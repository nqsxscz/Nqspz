using Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Wiener;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IWienerStochasticProcess<T> Wiener<T>()
        where T : IReal<T>
        => Wiener<T>(
            Guid
                .NewGuid()
                .GetHashCode());
    
    public static IWienerStochasticProcess<T> Wiener<T>(int id)
        where T : IReal<T>
        => new StandardWienerStochasticProcess<T>(id);
}