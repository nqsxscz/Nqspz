using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface ISelectProcess<T1, out T2>
    : IProcess<T2>
    where T1 : notnull
    where T2 : notnull
{
    IProcess<T1> Operand { get; }

    Func<T1, T2> Selector { get; }

    ITypeConstructor<TC, T2> IProcess<T2>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}