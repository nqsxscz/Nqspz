using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> ArithmeticBrownianMotion<T>(
        T init,
        T mu,
        T sigma,
        Func<TimeSpan, T> converter)
        where T : IReal<T>
        => ArithmeticBrownianMotion(
            init, 
            mu, 
            sigma, 
            Wiener(converter));
    
    public static IStochasticProcess<T> ArithmeticBrownianMotion<T>(
        T init,
        T mu,
        T sigma,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init,
            _ => mu, 
            _ => sigma, 
            wiener);
}