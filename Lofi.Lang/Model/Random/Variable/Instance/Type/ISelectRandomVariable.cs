using Lofi.Lang.Model.Random.Variable.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Type;

public interface ISelectRandomVariable<T1, out T2>
    : IRandomVariable<T2>
    where T1 : notnull
    where T2 : notnull
{
    IRandomVariable<T1> Operand { get; }
    
    Func<T1, T2> Selector { get; }

    TResult IRandomVariable<T2>.Accept<TResult>(
        IRandomVariableVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T2> IRandomVariable<T2>.Accept<TC>(
        IRandomVariableVisitor1<TC> visitor)
        => visitor.Visit(this);
}