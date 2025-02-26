using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant;

public static partial class StochasticProcess
{
    public static IPiecewiseConstantStochasticProcess<T2>
        Select<T1, T2>(
            this IPiecewiseConstantStochasticProcess<T1> operand,
            Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => Continuous.StochasticProcess
            .Select(
                operand, 
                selector)
            .Discretize(operand.Times());
}