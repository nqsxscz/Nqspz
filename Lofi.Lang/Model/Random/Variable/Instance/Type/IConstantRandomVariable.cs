using Lofi.Lang.Model.Random.Variable.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Type;

public interface IConstantRandomVariable<out T>
    : IRandomVariable<T>
    where T : notnull
{
    T Value { get; }

    TResult IRandomVariable<T>.Accept<TResult>(
        IRandomVariableVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IRandomVariable<T>.Accept<TC>(
        IRandomVariableVisitor1<TC> visitor)
        => visitor.Visit(this);
}