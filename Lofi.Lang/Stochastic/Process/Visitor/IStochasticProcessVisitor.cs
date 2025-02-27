using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Constant;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Lift;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Offset;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Select;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Time;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Stochastic.Process.Visitor;

public interface IStochasticProcessVisitor<out TResult>
    where TResult : notnull
{
    TResult Visit(
        ITimeStochasticProcess process);
    
    TResult Visit<T>(
        IStandardWienerStochasticProcess<T> process)
        where T : IReal<T>;
    
    TResult Visit<T>(
        ICorrelatedWienerStochasticProcess<T> process)
        where T : IReal<T>;
    
    TResult Visit<T>(
        IConstantStochasticProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IGenericDifferentialStochasticProcess<T> process)
        where T : IAdditiveGroup<T>;
    
    TResult Visit<T>(
        ITimeDifferentialStochasticProcess<T> process)
        where T : IAdditiveGroup<T>;
    
    TResult Visit<T>(
        IWienerDifferentialStochasticProcess<T> process)
        where T : IReal<T>;
    
    TResult Visit<T>(
        IOffsetStochasticProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IItoStochasticProcess<T> process)
        where T : 
        IReal<T>;

    TResult Visit<T1, T2>(
        ISelectStochasticProcess<T1, T2> process)
        where T1 : notnull
        where T2 : notnull;
    
    TResult Visit<T1, T2, T3>(
        ILiftStochasticProcess<T1, T2, T3> process)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}