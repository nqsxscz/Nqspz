using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous.Instance.TypeConstructor;

public interface ITemporal : IApplicative<ITemporal>
{
    static ITypeConstructor<ITemporal, T2>
        IFunctor<ITemporal>.Select<T1, T2>(
            ITypeConstructor<ITemporal, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToTemporal()
            .Select(selector);

    static ITypeConstructor<ITemporal, T>
        IApplicative<ITemporal>.Pure<T>(T t)
        => t.ToTemporal();

    static ITypeConstructor<ITemporal, T3>
        IApplicative<ITemporal>.Lift<T1, T2, T3>(
            ITypeConstructor<ITemporal, T1> left,
            ITypeConstructor<ITemporal, T2> right,
            Func<T1, T2, T3> combinator)
        => Temporal.Lift(
            left.ToTemporal(),
            right.ToTemporal(),
            combinator);
}