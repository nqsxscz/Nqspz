using Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Constant;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> ToStochasticProcess<T>(
        this ITypeConstructor<IStochasticProcess, T> process)
        where T : notnull
        => (IStochasticProcess<T>) process;
    
    public static IStochasticProcess<T> ToStochasticProcess<T>(
        this T t)
        where T : notnull
        => new ConstantStochasticProcess<T>(t);
}