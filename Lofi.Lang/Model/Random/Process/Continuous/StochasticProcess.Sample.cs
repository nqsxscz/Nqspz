using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Lang.Model.Random.Sample.Type;
using Lofi.Lang.Model.Random.Trajectory;
using Lofi.Lang.Model.Random.Trajectory.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static ITrajectory<T> Sample<T>(
        this IStochasticProcess<T> process,
        ISampler sampler,
        ISeq<DateTime> times)
        where T : notnull
        => process
            .Accept(
                ProcessVisitor
                    .Sample(
                        sampler, 
                        times))
            .ToTrajectory();
}