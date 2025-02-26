using Lofi.Lang.Model.Random.Variable.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Type;

public interface ILiftRandomVariable<T1, T2, out T3>
    : IRandomVariable<T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
{
    IRandomVariable<T1> Left { get; }
    
    IRandomVariable<T2> Right { get; }
    
    Func<T1, T2, T3> Combinator { get; }

    TResult IRandomVariable<T3>.Accept<TResult>(
        IRandomVariableVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T3> IRandomVariable<T3>.Accept<TC>(
        IRandomVariableVisitor1<TC> visitor)
        => visitor.Visit(this);
}