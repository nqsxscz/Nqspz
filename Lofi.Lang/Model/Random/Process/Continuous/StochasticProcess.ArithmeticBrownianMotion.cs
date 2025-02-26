using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> ArithmeticBrownianMotion<T>(
        T mu,
        T sigma,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Ito(
            _ => mu, 
            _ => sigma, 
            g);
}