using Lofi.Lang.Model.Random.Variable.Instance.TypeConstructor;
using Lofi.Lang.Model.Random.Variable.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Type;

public interface IRandomVariable<out T>
    : ITypeConstructor<IRandomVariable, T>
    where T : notnull
{
    TResult Accept<TResult>(
        IRandomVariableVisitor<TResult> visitor)
        where TResult : notnull;
    
    ITypeConstructor<TC, T> Accept<TC>(
        IRandomVariableVisitor1<TC> visitor)
        where TC : notnull;
}