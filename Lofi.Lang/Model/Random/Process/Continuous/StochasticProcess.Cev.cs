using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Cev<T>(
        T mu,
        T sigma,
        T gamma,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Ito(
            s => mu * s, 
            s => sigma * (s^gamma), 
            g);
}