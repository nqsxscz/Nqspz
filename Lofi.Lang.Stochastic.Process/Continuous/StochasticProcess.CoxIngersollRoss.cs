using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> CoxIngersollRoss<T>(
        T init,
        T theta,
        T mu,
        T sigma,
        Func<TimeSpan, T> converter)
        where T : IReal<T>
        => CoxIngersollRoss(
            init, 
            theta, 
            mu, 
            sigma, 
            Wiener(converter));

    private static IStochasticProcess<T> CoxIngersollRoss<T>(
        T init,
        T theta,
        T mu,
        T sigma,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
    {
        if (T.Two * mu * theta < sigma * sigma)
            throw new ArgumentException();
        return Ito(
            init, 
            s => theta * (mu - s),
            s => sigma * T.Sqrt(s),
            wiener);
    }
}