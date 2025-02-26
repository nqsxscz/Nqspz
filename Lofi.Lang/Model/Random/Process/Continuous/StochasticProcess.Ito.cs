using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    // dXt = f(Xt)dt + g(Xt)dWt
    public static IStochasticProcess<T> Ito<T>(
        Func<T, T> drift,
        Func<T, T> volatility,
        Func<TimeSpan, T> h)
        where T :
        IReal<T>
    {
        var left = 
            Integrate(
                drift, 
                Time().Differentiate(h));
        var right = 
            Integrate(
                volatility, 
                Wiener<T>().Differentiate());
        return left.Add(right);
    }
}