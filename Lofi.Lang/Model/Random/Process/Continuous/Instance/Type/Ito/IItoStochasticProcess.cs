using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Ito;

public interface IItoStochasticProcess<T>
    : IStochasticProcess<T>
    where T : 
    IAdditiveGroup<T>,
    IMultiplicativeSemigroup<T>
{
    T Init { get; }
    
    Func<T, T, T> Drift { get; }
    
    Func<T, T, T> Volatility { get; }
    
    Func<TimeSpan, T> Converter { get; }
    
    IStochasticProcess<T> Left { get; }
    
    IStochasticProcess<T> Right { get; }
    
    IStochasticProcess<T> Wiener { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}