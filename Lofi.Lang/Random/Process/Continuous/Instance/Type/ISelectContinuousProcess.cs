using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface ISelectContinuousProcess<T1, out T2>
    : IContinuousProcess<T2>
    where T1 : notnull
    where T2 : notnull
{
    IContinuousProcess<T1> Operand { get; }

    Func<T1, T2> Selector { get; }

    ITypeConstructor<TC, T2> IContinuousProcess<T2>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}