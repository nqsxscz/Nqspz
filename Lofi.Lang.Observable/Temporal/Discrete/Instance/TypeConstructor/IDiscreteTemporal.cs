using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete.Instance.TypeConstructor;

public interface IDiscreteTemporal : 
    IApplicative<IDiscreteTemporal>,
    IScannable<IDiscreteTemporal>
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

    static ITypeConstructor<IDiscreteTemporal, T2>
        IScannable<IDiscreteTemporal>.ScanRight<T1, T2>(
            ITypeConstructor<IDiscreteTemporal, T1> operand,
            T2 init,
            Func<T1, T2, T2> accumulator)
        => operand
            .ToDiscreteTemporal()
            .ScanRight(
                init, 
                accumulator);
}