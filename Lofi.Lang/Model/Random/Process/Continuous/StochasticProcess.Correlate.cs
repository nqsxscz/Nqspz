using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Correlated;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Correlate<T>(
        this IStochasticProcess<T> operand,
        T correlation)
        where T : IReal<T>
        => new CorrelatedStochasticProcess<T>(
            operand, 
            correlation);
}