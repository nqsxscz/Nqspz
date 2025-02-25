using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Ckls<T>(
        ISeq<DateTime> times,
        T init,
        T alpha,
        T beta,
        T sigma,
        T gamma,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Of(
            times,
            init,
            Ckls(
                alpha,
                beta,
                sigma,
                gamma),
            g);
    
    private static Func<T, T, T, T> Ckls<T>(
        T alpha,
        T beta,
        T sigma,
        T gamma)
        where T : IReal<T>
        => (st, dt, dwt)
            => (alpha + beta * st) * dt + sigma * (st^gamma) * dwt;
}