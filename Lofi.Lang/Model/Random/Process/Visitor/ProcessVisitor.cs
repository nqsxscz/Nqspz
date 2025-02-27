using Lofi.Lang.Model.Random.Process.Visitor.Sample.Implementation;
using Lofi.Lang.Model.Random.Sample.Type;
using Lofi.Lang.Model.Random.Trajectory.TypeConstructor;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.Visitor;

public static class ProcessVisitor
{
    public static IContinuousProcessVisitor1<ITrajectory>
        Sample(
            ISampler sampler, 
            ISeq<DateTime> times)
        => new SampleVisitor(
            sampler, 
            times);
}