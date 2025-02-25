using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Sabr<T>(
        ISeq<DateTime> times,
        T init1,
        T init2,
        T alpha,
        T beta,
        T rho,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Sabr(
            Wiener<T>(times), 
            init1, 
            init2, 
            alpha, 
            beta, 
            rho, 
            g);
    
    private static IStochasticProcess<T> Sabr<T>(
        IStochasticProcess<T> wiener,
        T init1,
        T init2,
        T alpha,
        T beta,
        T rho,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Of(
            wiener,
            SabrVolatility(
                wiener, 
                init2, 
                alpha, 
                rho, 
                g),
            init1,
            Sabr(beta),
            g);
    
    private static Func<T, T, T, T, T> Sabr<T>(
        T beta)
        where T : IReal<T>
        => (ft, _, dwt, vt)
            => vt * (ft^beta) * dwt;

    private static IStochasticProcess<T> SabrVolatility<T>(
        IStochasticProcess<T> wiener,
        T init,
        T alpha,
        T rho,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Of(
            wiener.Correlate(rho),
            init,
            SabrVolatility(alpha),
            g);

    private static Func<T, T, T, T> SabrVolatility<T>(
        T alpha)
        where T : IReal<T>
        => (vt, _, dwt)
            => alpha * vt * dwt;
}