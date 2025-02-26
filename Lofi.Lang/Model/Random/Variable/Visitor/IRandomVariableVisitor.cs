using Lofi.Lang.Model.Random.Variable.Instance.Type;

namespace Lofi.Lang.Model.Random.Variable.Visitor;

public interface IRandomVariableVisitor<out TResult>
    where TResult : notnull
{
    TResult Visit<T>(
        IConstantRandomVariable<T> randomVariable)
        where T : notnull;
}