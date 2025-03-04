using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> GeometricBrownianMotion<T>(
        T init,
        T mu,
        T sigma,
        Func<TimeSpan, T> converter)
        where T : IReal<T>
        => GeometricBrownianMotion(
            init, 
            mu, 
            sigma, 
            Wiener(converter));
    
    public static IStochasticProcess<T> GeometricBrownianMotion<T>(
        T init,
        T mu,
        T sigma,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init,
            s => mu * s, 
            s => sigma * s, 
            wiener);
}