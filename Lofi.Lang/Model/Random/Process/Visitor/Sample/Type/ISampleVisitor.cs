using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Constant;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Lift;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Offset;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Select;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Time;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Wiener;
using Lofi.Lang.Model.Random.Sample.Type;
using Lofi.Lang.Model.Random.Trajectory.TypeConstructor;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Visitor.Sample.Type;

public interface ISampleVisitor
    : IContinuousProcessVisitor1<ITrajectory>
{
    ISampler Sampler { get; }
    
    ISeq<DateTime> Times { get; }

    ITypeConstructor<ITrajectory, DateTime>
        IContinuousProcessVisitor1<ITrajectory>.Visit(
            ITimeStochasticProcess process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T>(
            IWienerStochasticProcess<T> process)
        => Sampler.Sample(process, Times);
    
    ITypeConstructor<ITrajectory, T> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T>(
            ICorrelatedWienerStochasticProcess<T> process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T>(
            IConstantStochasticProcess<T> process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T>(
            IGenericDifferentialStochasticProcess<T> process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T>(
            ITimeDifferentialStochasticProcess<T> process)
        => Sampler.Sample(process, Times);
    
    ITypeConstructor<ITrajectory, T> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T>(
            IWienerDifferentialStochasticProcess<T> process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T>(
            IOffsetStochasticProcess<T> process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T>(
            IItoStochasticProcess<T> process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T2> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T1, T2>(
            ISelectStochasticProcess<T1, T2> process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T3> 
        IContinuousProcessVisitor1<ITrajectory>.Visit<T1, T2, T3>(
            ILiftStochasticProcess<T1, T2, T3> process)
        => Sampler.Sample(process, Times);
}