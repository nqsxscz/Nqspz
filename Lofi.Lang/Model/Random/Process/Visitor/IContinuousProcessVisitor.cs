using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Constant;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Correlated;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Ito;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Lift;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Offset;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Select;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Time;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Visitor;

public interface IContinuousProcessVisitor<out TResult>
    : IPiecewiseConstantProcessVisitor<TResult>
    where TResult : notnull
{
    TResult Visit(
        ITimeStochasticProcess process);
    
    TResult Visit<T>(
        IWienerStochasticProcess<T> process)
        where T : IReal<T>;
    
    TResult Visit<T>(
        IConstantStochasticProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        ICorrelatedStochasticProcess<T> process)
        where T : IReal<T>;
    
    TResult Visit<T>(
        IGenericDifferentialStochasticProcess<T> process)
        where T : IAdditiveGroup<T>;
    
    TResult Visit<T>(
        ITimeDifferentialStochasticProcess<T> process)
        where T : IAdditiveGroup<T>;
    
    TResult Visit<T>(
        IOffsetStochasticProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IItoStochasticProcess<T> process)
        where T : 
        IAdditiveGroup<T>,
        IMultiplicativeSemigroup<T>;

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