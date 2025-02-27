using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Ito;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    // dXt = f(Xt)dt + g(Xt)dWt
    public static IStochasticProcess<T> Ito<T>(
        T init,
        Func<T, T> drift,
        Func<T, T> volatility,
        Func<TimeSpan, T> converter,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init, 
            drift, 
            (x, _) => volatility(x), 
            converter,
            T.Zero.ToStochasticProcess(),
            wiener);
    
    
    // dXt = f(Xt, At)dt + g(Xt)dWt
    public static IStochasticProcess<T> Ito<T>(
        T init,
        Func<T, T, T> drift,
        Func<T, T> volatility,
        Func<TimeSpan, T> converter,
        IStochasticProcess<T> operand,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init, 
            drift, 
            (x, _) => volatility(x), 
            converter,
            operand,
            T.Zero.ToStochasticProcess(),
            wiener);
    
    // dXt = f(Xt)dt + g(Xt, At)dWt
    public static IStochasticProcess<T> Ito<T>(
        T init,
        Func<T, T> drift,
        Func<T, T, T> volatility,
        Func<TimeSpan, T> converter,
        IStochasticProcess<T> operand,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init, 
            (x, _) => drift(x), 
            volatility, 
            converter, 
            T.Zero.ToStochasticProcess(), 
            operand,
            wiener);
    
    // dXt = f(Xt, At)dt + g(Xt, At)dWt
    public static IStochasticProcess<T> Ito<T>(
        T init,
        Func<T, T, T> drift,
        Func<T, T, T> volatility,
        Func<TimeSpan, T> converter,
        IStochasticProcess<T> operand,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => Ito(
            init, 
            drift, 
            volatility, 
            converter, 
            operand, 
            operand,
            wiener);
    
    // dXt = f(Xt, At)dt + g(Xt, Bt)dWt
    public static IStochasticProcess<T> Ito<T>(
        T init,
        Func<T, T, T> drift,
        Func<T, T, T> volatility,
        Func<TimeSpan, T> converter,
        IStochasticProcess<T> left,
        IStochasticProcess<T> right,
        IWienerStochasticProcess<T> wiener)
        where T : IReal<T>
        => new ItoStochasticProcess<T>(
            init, 
            drift, 
            volatility,
            converter, 
            left,
            right,
            wiener);
}