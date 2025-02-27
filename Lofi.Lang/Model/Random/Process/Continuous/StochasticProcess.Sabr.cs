using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Sabr<T>(
        T init1,
        T init2,
        T alpha,
        T beta,
        T rho,
        Func<TimeSpan, T> converter)
        where T : IReal<T>
        => Sabr( 
            init1,
            init2,
            alpha, 
            beta, 
            rho,
            converter,
            Wiener<T>());
    
    private static IStochasticProcess<T> Sabr<T>(
        T init1,
        T init2,
        T alpha,
        T beta,
        T rho,
        Func<TimeSpan, T> converter,
        IStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init1,
            _ => T.Zero,
            (f, sigma) => sigma * (f ^ beta),
            converter,
            SabrVolatility( 
                init2,
                alpha, 
                rho,
                converter,
                wiener),
            wiener);
    
    private static IStochasticProcess<T> SabrVolatility<T>(
        T init,
        T alpha,
        T rho,
        Func<TimeSpan, T> converter,
        IStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init,
            _ => T.Zero,
            sigma => alpha * sigma,
            converter,
            wiener.Correlate(rho));
}