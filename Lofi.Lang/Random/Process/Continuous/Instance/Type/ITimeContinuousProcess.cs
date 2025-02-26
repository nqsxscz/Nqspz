using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface ITimeContinuousProcess
    : IContinuousProcess<DateTime>
{
    ITypeConstructor<TC, DateTime> IContinuousProcess<DateTime>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}