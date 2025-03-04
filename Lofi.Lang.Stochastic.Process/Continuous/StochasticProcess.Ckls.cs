using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Ckls<T>(
        T init,
        T alpha,
        T beta,
        T sigma,
        T gamma,
        Func<TimeSpan, T> converter)
        where T : IReal<T>
        => Ckls(
            init, 
            alpha, 
            beta, 
            sigma, 
            gamma, 
            Wiener(converter));
    
    private static IStochasticProcess<T> Ckls<T>(
        T init,
        T alpha,
        T beta,
        T sigma,
        T gamma,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init,
            s => alpha + beta * s, 
            s => sigma * (s^gamma), 
            wiener);
}