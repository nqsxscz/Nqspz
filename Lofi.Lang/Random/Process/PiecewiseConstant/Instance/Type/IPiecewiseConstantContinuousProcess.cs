using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.TypeConstructor;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface IPiecewiseConstantContinuousProcess<out T> :
    IContinuousProcess<T>,
    ITypeConstructor<IPiecewiseConstantProcess, T>
    where T : notnull
{
    TResult Accept<TResult>(
        IPiecewiseConstantProcessVisitor<TResult> visitor)
        where TResult : notnull;
    
    ITypeConstructor<TC, T> Accept<TC>(
        IPiecewiseConstantProcessVisitor1<TC> visitor)
        where TC : notnull;
}