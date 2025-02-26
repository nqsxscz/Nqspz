using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.TypeConstructor;
using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;

public interface IPiecewiseConstantStochasticProcess<out T> :
    IStochasticProcess<T>,
    ITypeConstructor<IPiecewiseConstantStochasticProcess, T>
    where T : notnull
{
    TResult Accept<TResult>(
        IPiecewiseConstantProcessVisitor<TResult> visitor)
        where TResult : notnull;
    
    ITypeConstructor<TC, T> Accept<TC>(
        IPiecewiseConstantProcessVisitor1<TC> visitor)
        where TC : notnull;
}