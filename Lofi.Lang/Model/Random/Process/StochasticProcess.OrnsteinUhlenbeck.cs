using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> OrnsteinUhlenbeck<T>(
        ISeq<DateTime> times,
        T init,
        T theta,
        T mu,
        T sigma,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Of(
            times,
            init,
            OrnsteinUhlenbeck(
                theta, 
                mu, 
                sigma),
            g);
    
    private static Func<T, T, T, T> OrnsteinUhlenbeck<T>(
        T theta,
        T mu,
        T sigma)
        where T : IReal<T>
        => (st, dt, dwt)
            => theta * (mu - st) * dt + sigma * dwt;
}