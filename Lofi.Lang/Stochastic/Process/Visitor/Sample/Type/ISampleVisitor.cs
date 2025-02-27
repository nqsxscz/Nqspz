using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Constant;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Lift;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Offset;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Select;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Time;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Lang.Stochastic.Sample.Type;
using Lofi.Lang.Stochastic.Trajectory.TypeConstructor;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Visitor.Sample.Type;

public interface ISampleVisitor
    : IStochasticProcessVisitor1<ITrajectory>
{
    ISampler Sampler { get; }
    
    ISeq<DateTime> Times { get; }
    
    int Seed { get; }

    ITypeConstructor<ITrajectory, DateTime>
        IStochasticProcessVisitor1<ITrajectory>.Visit(
            ITimeStochasticProcess process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T>(
            IStandardWienerStochasticProcess<T> process)
        => Sampler.Sample(process, Times, Seed);
    
    ITypeConstructor<ITrajectory, T> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T>(
            ICorrelatedWienerStochasticProcess<T> process)
        => Sampler.Sample(process, Times, Seed);

    ITypeConstructor<ITrajectory, T> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T>(
            IConstantStochasticProcess<T> process)
        => Sampler.Sample(process, Times);

    ITypeConstructor<ITrajectory, T> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T>(
            IGenericDifferentialStochasticProcess<T> process)
        => Sampler.Sample(process, Times, Seed);

    ITypeConstructor<ITrajectory, T> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T>(
            ITimeDifferentialStochasticProcess<T> process)
        => Sampler.Sample(process, Times);
    
    ITypeConstructor<ITrajectory, T> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T>(
            IWienerDifferentialStochasticProcess<T> process)
        => Sampler.Sample(process, Times, Seed);

    ITypeConstructor<ITrajectory, T> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T>(
            IOffsetStochasticProcess<T> process)
        => Sampler.Sample(process, Times, Seed);

    ITypeConstructor<ITrajectory, T> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T>(
            IItoStochasticProcess<T> process)
        => Sampler.Sample(process, Times, Seed);

    ITypeConstructor<ITrajectory, T2> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T1, T2>(
            ISelectStochasticProcess<T1, T2> process)
        => Sampler.Sample(process, Times, Seed);

    ITypeConstructor<ITrajectory, T3> 
        IStochasticProcessVisitor1<ITrajectory>.Visit<T1, T2, T3>(
            ILiftStochasticProcess<T1, T2, T3> process)
        => Sampler.Sample(process, Times, Seed);
}