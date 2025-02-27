using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Sample.Type;
using Lofi.Lang.Stochastic.Sample.Visitor;
using Lofi.Lang.Stochastic.Trajectory;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Sample;

public static class Sampler
{
    public static ITrajectory<T> Sample<T>(
        this IStochasticProcess<T> process,
        ISampler sampler,
        ISeq<DateTime> times,
        int seed)
        where T : notnull
        => process
            .Accept(
                StochasticProcessVisitor
                    .Sample(
                        sampler, 
                        times,
                        seed))
            .ToTrajectory();
}