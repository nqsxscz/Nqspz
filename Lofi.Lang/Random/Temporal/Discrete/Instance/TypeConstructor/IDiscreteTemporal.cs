using Lofi.Lang.Random.Temporal.Continuous;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Temporal.Discrete.Instance.TypeConstructor;

public interface IDiscreteTemporal : Trait.IObservable<IDiscreteTemporal>,
    IApplicative<IDiscreteTemporal>
{
    static ITypeConstructor<IDiscreteTemporal, T2>
        IFunctor<IDiscreteTemporal>.Select<T1, T2>(
            ITypeConstructor<IDiscreteTemporal, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToDiscreteTemporal()
            .Select(selector);

    static ITypeConstructor<IDiscreteTemporal, T>
        IApplicative<IDiscreteTemporal>.Pure<T>(T t)
        => t.ToDiscreteTemporal();

    static ITypeConstructor<IDiscreteTemporal, T3>
        IApplicative<IDiscreteTemporal>.Lift<T1, T2, T3>(
            ITypeConstructor<IDiscreteTemporal, T1> left,
            ITypeConstructor<IDiscreteTemporal, T2> right,
            Func<T1, T2, T3> combinator)
        => Temporal.Lift(
            left.ToDiscreteTemporal(),
            right.ToDiscreteTemporal(),
            combinator);

    static IMaybe<T> Trait.IObservable<IDiscreteTemporal>.Observe<T>(
        ITypeConstructor<IDiscreteTemporal, T> observable,
        DateTime t)
        => observable
            .ToDiscreteTemporal()
            .Observe(t);
}