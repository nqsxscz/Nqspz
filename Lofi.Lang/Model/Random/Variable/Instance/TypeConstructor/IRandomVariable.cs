using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.TypeConstructor;

public interface IRandomVariable : 
    IApplicative<IRandomVariable>
{
    static ITypeConstructor<IRandomVariable, T2>
        IFunctor<IRandomVariable>.Select<T1, T2>(
            ITypeConstructor<IRandomVariable, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToRandomVariable()
            .Select(selector);

    static ITypeConstructor<IRandomVariable, T>
        IApplicative<IRandomVariable>.Pure<T>(T t)
        => t.ToRandomVariable();

    static ITypeConstructor<IRandomVariable, T3>
        IApplicative<IRandomVariable>.Lift<T1, T2, T3>(
            ITypeConstructor<IRandomVariable, T1> left,
            ITypeConstructor<IRandomVariable, T2> right,
            Func<T1, T2, T3> combinator)
        => RandomVariable.Lift(
            left.ToRandomVariable(),
            right.ToRandomVariable(),
            combinator);
}