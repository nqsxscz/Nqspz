using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Cev<T>(
        ISeq<DateTime> times,
        T init,
        T mu,
        T sigma,
        T gamma,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Of(
            times,
            init,
            Cev(
                mu, 
                sigma,
                gamma),
            g);
    
    private static Func<T, T, T, T> Cev<T>(
        T mu,
        T sigma,
        T gamma)
        where T : IReal<T>
        => (st, dt, dwt)
            => mu * st * dt + sigma * (st^gamma) * dwt;
}