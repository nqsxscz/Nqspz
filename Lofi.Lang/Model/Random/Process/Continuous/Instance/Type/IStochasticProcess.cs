using Lofi.Lang.Model.Random.Process.Continuous.Instance.TypeConstructor;
using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;

public interface IStochasticProcess<out T>
    : ITypeConstructor<IStochasticProcess, T>
    where T : notnull
{
    TResult Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        where TResult : notnull;
    
    ITypeConstructor<TC, T> Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        where TC : notnull;
}