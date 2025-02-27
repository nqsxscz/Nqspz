using Lofi.Lang.Stochastic.Process.Continuous.Instance.TypeConstructor;
using Lofi.Lang.Stochastic.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;

public interface IStochasticProcess<out T>
    : ITypeConstructor<IStochasticProcess, T>
    where T : notnull
{
    TResult Accept<TResult>(
        IStochasticProcessVisitor<TResult> visitor)
        where TResult : notnull;
    
    ITypeConstructor<TC, T> Accept<TC>(
        IStochasticProcessVisitor1<TC> visitor)
        where TC : notnull;
}