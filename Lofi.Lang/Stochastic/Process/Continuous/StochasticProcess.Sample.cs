using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Visitor;
using Lofi.Lang.Stochastic.Sample.Type;
using Lofi.Lang.Stochastic.Trajectory;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static ITrajectory<T> Sample<T>(
        this IStochasticProcess<T> process,
        ISampler sampler,
        ISeq<DateTime> times)
        where T : notnull
        => process
            .Accept(
                StochasticProcessVisitor
                    .Sample(
                        sampler, 
                        times))
            .ToTrajectory();
}