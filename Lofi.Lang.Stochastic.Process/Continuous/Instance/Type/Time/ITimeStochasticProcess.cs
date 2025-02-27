using Lofi.Lang.Stochastic.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Time;

public interface ITimeStochasticProcess
    : IStochasticProcess<DateTime>
{
    TResult IStochasticProcess<DateTime>.Accept<TResult>(
        IStochasticProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, DateTime> IStochasticProcess<DateTime>.Accept<TC>(
        IStochasticProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}