using Lofi.Lang.Model.Random.Process.Continuous;
using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.TypeConstructor;
using Lofi.Prelude.Data;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant;

public static partial class StochasticProcess
{
    public static IPiecewiseConstantStochasticProcess<T> 
        ToPiecewiseConstantStochasticProcess<T>(
            this ITypeConstructor<IPiecewiseConstantStochasticProcess, T> process)
        where T : notnull
        => (IPiecewiseConstantStochasticProcess<T>) process;
    
    public static IPiecewiseConstantStochasticProcess<T> 
        ToPiecewiseConstantStochasticProcess<T>(
            this T t)
        where T : notnull
        => t.ToStochasticProcess()
            .Discretize(Seq.Empty<DateTime>());
}