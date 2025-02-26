using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Implementation;
using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant;

public static partial class StochasticProcess
{
    public static IPiecewiseConstantStochasticProcess<T>
        Discretize<T>(
            this IStochasticProcess<T> operand, 
            ISeq<DateTime> times)
        where T : notnull
        => new DiscretizedPiecewiseConstantStochasticProcess<T>(
            operand, 
            times);
}