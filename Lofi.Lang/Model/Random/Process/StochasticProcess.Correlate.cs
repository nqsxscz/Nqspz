using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Correlate<T>(
        this IStochasticProcess<T> operand,
        T correlation)
        where T : IReal<T>
        => throw new NotImplementedException();
}