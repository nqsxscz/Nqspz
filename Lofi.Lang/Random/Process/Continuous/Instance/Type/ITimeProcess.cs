using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface ITimeProcess
    : IProcess<DateTime>
{
    ITypeConstructor<TC, DateTime> IProcess<DateTime>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}