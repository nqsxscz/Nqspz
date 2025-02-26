using Lofi.Lang.Model.Random.Variable.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable.Visitor;

public interface IRandomVariableVisitor1<TC>
    where TC : notnull
{
    ITypeConstructor<TC, T> Visit<T>(
        IConstantRandomVariable<T> randomVariable)
        where T : notnull;

    ITypeConstructor<TC, T2> Visit<T1, T2>(
        ISelectRandomVariable<T1, T2> randomVariable)
        where T1 : notnull
        where T2 : notnull;

    ITypeConstructor<TC, T3> Visit<T1, T2, T3>(
        ILiftRandomVariable<T1, T2, T3> randomVariable)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}