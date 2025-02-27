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
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Visitor;

public interface IStochasticProcessVisitor1<TC>
    where TC : notnull
{
    ITypeConstructor<TC, DateTime> Visit(
        ITimeStochasticProcess process);
    
    ITypeConstructor<TC, T> Visit<T>(
        IWienerStochasticProcess<T> process)
        where T : IReal<T>;
    
    ITypeConstructor<TC, T> Visit<T>(
        ICorrelatedWienerStochasticProcess<T> process)
        where T : IReal<T>;
    
    ITypeConstructor<TC, T> Visit<T>(
        IConstantStochasticProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IGenericDifferentialStochasticProcess<T> process)
        where T : IAdditiveGroup<T>;
    
    ITypeConstructor<TC, T> Visit<T>(
        ITimeDifferentialStochasticProcess<T> process)
        where T : IAdditiveGroup<T>;
    
    ITypeConstructor<TC, T> Visit<T>(
        IWienerDifferentialStochasticProcess<T> process)
        where T : IReal<T>;
    
    ITypeConstructor<TC, T> Visit<T>(
        IOffsetStochasticProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IItoStochasticProcess<T> process)
        where T : 
        IReal<T>;

    ITypeConstructor<TC, T2> Visit<T1, T2>(
        ISelectStochasticProcess<T1, T2> process)
        where T1 : notnull
        where T2 : notnull;
    
    ITypeConstructor<TC, T3> Visit<T1, T2, T3>(
        ILiftStochasticProcess<T1, T2, T3> process)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}