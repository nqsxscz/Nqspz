using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Numeric.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Correlated;

public interface ICorrelatedStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : IReal<T>
{
    IStochasticProcess<T> Operand { get; }
    
    T Correlation { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}