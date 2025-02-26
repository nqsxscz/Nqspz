using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Integral;

public interface IIntegralStochasticProcess<T>
    : IStochasticProcess<T>
    where T : 
    IAdditiveGroup<T>,
    IMultiplicativeSemigroup<T>
{
    Func<T, T, T> Function { get; }
    
    IStochasticProcess<T> Operand { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}