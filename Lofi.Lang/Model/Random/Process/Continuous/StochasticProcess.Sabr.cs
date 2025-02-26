using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    private static IStochasticProcess<T> Sabr<T>(
        T alpha,
        T beta,
        T rho)
        where T : IReal<T>
        => Sabr(
            Wiener<T>(), 
            alpha, 
            beta, 
            rho);
    
    private static IStochasticProcess<T> Sabr<T>(
        IStochasticProcess<T> wiener,
        T alpha,
        T beta,
        T rho)
        where T : IReal<T>
        => Integrate(
            (f, sigma) => sigma * (f ^ beta),
            SabrVolatility(
                wiener, 
                alpha, 
                rho),
            wiener.Differentiate());
    
    private static IStochasticProcess<T> SabrVolatility<T>(
        IStochasticProcess<T> wiener,
        T alpha,
        T rho)
        where T : IReal<T>
        => Integrate(
            sigma => alpha * sigma,
            wiener
                .Correlate(rho)
                .Differentiate());
}