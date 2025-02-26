using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Ckls<T>(
        T alpha,
        T beta,
        T sigma,
        T gamma,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Ito(
            s => alpha + beta * s, 
            s => sigma * (s^gamma), 
            g);
}