using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;
using Lofi.Lang.Stochastic.Process.Visitor;
using Lofi.Prelude.Numeric.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Ito;

public interface IItoStochasticProcess<T>
    : IStochasticProcess<T>
    where T : 
    IReal<T>
{
    T Init { get; }
    
    Func<T, T, T> Drift { get; }
    
    Func<T, T, T> Volatility { get; }
    
    Func<TimeSpan, T> Converter { get; }
    
    IStochasticProcess<T> Left { get; }
    
    IStochasticProcess<T> Right { get; }
    
    IWienerStochasticProcess<T> Wiener { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IStochasticProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IStochasticProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}