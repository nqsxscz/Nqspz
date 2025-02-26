using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface IEmptyContinuousProcess<out T>
    : IContinuousProcess<T>
    where T : notnull
{
    ITypeConstructor<TC, T> IContinuousProcess<T>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}