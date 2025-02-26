using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Implementation;
using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant;

public static partial class StochasticProcess
{
    public static IPiecewiseConstantStochasticProcess<T>
        Offset<T>(
            this IPiecewiseConstantStochasticProcess<T> operand, 
            int offset)
        where T : notnull
        => new OffsetPiecewiseConstantStochasticProcess<T>(
            operand, 
            offset);
}