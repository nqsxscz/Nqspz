using Lofi.Lang.Model.Random.Variable.Instance.Type;

namespace Lofi.Lang.Model.Random.Variable.Visitor;

public interface IRandomVariableVisitor<out TResult>
    where TResult : notnull
{
    TResult Visit<T>(
        IConstantRandomVariable<T> randomVariable)
        where T : notnull;

    TResult Visit<T1, T2>(
        ISelectRandomVariable<T1, T2> randomVariable)
        where T1 : notnull
        where T2 : notnull;

    TResult Visit<T1, T2, T3>(
        ILiftRandomVariable<T1, T2, T3> randomVariable)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}