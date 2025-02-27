using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Constant;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Lift;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Offset;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Select;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Time;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Lang.Stochastic.Trajectory.Type;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Sample.Type;

public interface ISampler
{
    ITrajectory<DateTime> Sample(
        ITimeStochasticProcess process,
        ISeq<DateTime> times);
    
    ITrajectory<T> Sample<T>(
        IWienerStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IReal<T>;
    
    ITrajectory<T> Sample<T>(
        ICorrelatedWienerStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IReal<T>;
    
    ITrajectory<T> Sample<T>(
        IConstantStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : notnull;
    
    ITrajectory<T> Sample<T>(
        IGenericDifferentialStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IAdditiveGroup<T>;
    
    ITrajectory<T> Sample<T>(
        ITimeDifferentialStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IAdditiveGroup<T>;
    
    ITrajectory<T> Sample<T>(
        IWienerDifferentialStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : IReal<T>;
    
    ITrajectory<T> Sample<T>(
        IOffsetStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : notnull;
    
    ITrajectory<T> Sample<T>(
        IItoStochasticProcess<T> process,
        ISeq<DateTime> times)
        where T : 
        IReal<T>;

    ITrajectory<T2> Sample<T1, T2>(
        ISelectStochasticProcess<T1, T2> process,
        ISeq<DateTime> times)
        where T1 : notnull
        where T2 : notnull;
    
    ITrajectory<T3> Sample<T1, T2, T3>(
        ILiftStochasticProcess<T1, T2, T3> process,
        ISeq<DateTime> times)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}