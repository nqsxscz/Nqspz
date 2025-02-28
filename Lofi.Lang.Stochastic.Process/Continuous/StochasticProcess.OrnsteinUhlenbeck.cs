using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> OrnsteinUhlenbeck<T>(
        T init,
        T theta,
        T mu,
        T sigma,
        Func<TimeSpan, T> converter)
        where T : IReal<T>
        => OrnsteinUhlenbeck(
            init, 
            theta, 
            mu, 
            sigma, 
            converter, 
            Wiener(converter));
    
    private static IStochasticProcess<T> OrnsteinUhlenbeck<T>(
        T init,
        T theta,
        T mu,
        T sigma,
        Func<TimeSpan, T> converter,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init,
            s => theta * (mu - s), 
            _ => sigma, 
            converter,
            wiener);
}