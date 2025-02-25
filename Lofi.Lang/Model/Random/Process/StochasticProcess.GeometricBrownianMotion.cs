using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> GeometricBrownianMotion<T>(
        ISeq<DateTime> times,
        T init,
        T mu,
        T sigma,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Of(
            times,
            init,
            GeometricBrownianMotion(
                mu, 
                sigma),
            g);
    
    private static Func<T, T, T, T> GeometricBrownianMotion<T>(
        T mu,
        T sigma)
        where T : IReal<T>
        => (st, dt, dwt)
            => mu * st * dt + sigma * st * dwt;
}