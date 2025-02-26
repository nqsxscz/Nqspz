using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant;

public static partial class StochasticProcess
{
    public static IPiecewiseConstantStochasticProcess<T3>
        Lift<T1, T2, T3>(
            IPiecewiseConstantStochasticProcess<T1> left,
            IPiecewiseConstantStochasticProcess<T2> right,
            Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => Continuous.StochasticProcess
            .Lift(
                left,
                right,
                combinator)
            .Discretize(
                left.Times()
                    .Union(right.Times())
                    .ToSeq());
}