using Lofi.Lang.Model.Random.Variable.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable.Visitor;

public interface IRandomVariableVisitor1<TC>
    where TC : notnull
{
    ITypeConstructor<TC, T> Visit<T>(
        IConstantRandomVariable<T> randomVariable)
        where T : notnull;
}