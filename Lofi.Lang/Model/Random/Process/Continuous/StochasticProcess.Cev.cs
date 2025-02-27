using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Cev<T>(
        T init,
        T mu,
        T sigma,
        T gamma,
        Func<TimeSpan, T> converter)
        where T : IReal<T>
        => Cev(
            init, 
            mu, 
            sigma, 
            gamma, 
            converter, 
            Wiener<T>());
    
    private static IStochasticProcess<T> Cev<T>(
        T init,
        T mu,
        T sigma,
        T gamma,
        Func<TimeSpan, T> converter,
        IStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init,
            s => mu * s, 
            s => sigma * (s^gamma), 
            converter,
            wiener);
}