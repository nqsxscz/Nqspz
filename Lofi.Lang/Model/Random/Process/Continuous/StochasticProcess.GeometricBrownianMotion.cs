using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

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
            converter, 
            Wiener<T>());
    
    private static IStochasticProcess<T> GeometricBrownianMotion<T>(
        T init,
        T mu,
        T sigma,
        Func<TimeSpan, T> converter,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init,
            s => mu * s, 
            s => sigma * s, 
            converter,
            wiener);
}