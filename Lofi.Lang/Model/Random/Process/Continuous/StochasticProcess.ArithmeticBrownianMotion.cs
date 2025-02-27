using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

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
            converter, 
            Wiener<T>());
    
    private static IStochasticProcess<T> ArithmeticBrownianMotion<T>(
        T init,
        T mu,
        T sigma,
        Func<TimeSpan, T> converter,
        IStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init,
            _ => mu, 
            _ => sigma, 
            converter,
            wiener);
}