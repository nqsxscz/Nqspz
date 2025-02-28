using Lofi.Lang.Stochastic.Process.Visitor;
using Lofi.Lang.Stochastic.Sample.Type;
using Lofi.Lang.Stochastic.Sample.Visitor.Implementation;
using Lofi.Lang.Stochastic.Trajectory.TypeConstructor;
using Lofi.Prelude.Data.Control.Instance.Seq.Type;

namespace Lofi.Lang.Stochastic.Sample.Visitor;

public static class StochasticProcessVisitor
{
    public static IStochasticProcessVisitor1<ITrajectory>
        Sample(
            ISampler sampler, 
            ISeq<DateTime> times,
            int seed)
        => new SampleVisitor(
            sampler, 
            times,
            seed);
}