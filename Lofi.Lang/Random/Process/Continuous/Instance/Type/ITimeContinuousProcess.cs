using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface ITimeContinuousProcess
    : IContinuousProcess<DateTime>
{
    TResult IContinuousProcess<DateTime>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, DateTime> IContinuousProcess<DateTime>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}