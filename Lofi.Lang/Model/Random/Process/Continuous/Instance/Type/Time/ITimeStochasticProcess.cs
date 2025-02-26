using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Time;

public interface ITimeStochasticProcess
    : IStochasticProcess<DateTime>
{
    TResult IStochasticProcess<DateTime>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, DateTime> IStochasticProcess<DateTime>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}