using Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Select;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T2> Select<T1, T2>(
        this IStochasticProcess<T1> operand,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => new SelectStochasticProcess<T1,T2>(
            operand, 
            selector);
}