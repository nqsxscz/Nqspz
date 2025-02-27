using Lofi.Lang.Stochastic.Process.Visitor;
using Lofi.Prelude.Numeric.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Wiener;

public interface IWienerStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : IReal<T>
{
    TResult IStochasticProcess<T>.Accept<TResult>(
        IStochasticProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IStochasticProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}