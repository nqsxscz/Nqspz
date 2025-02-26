using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.TypeConstructor;

public interface IContinuousProcess : Trait.IObservable<IContinuousProcess>,
    IApplicative<IContinuousProcess>
{
    static ITypeConstructor<IContinuousProcess, T2>
        IFunctor<IContinuousProcess>.Select<T1, T2>(
            ITypeConstructor<IContinuousProcess, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToContinuousProcess()
            .Select(selector);

    static ITypeConstructor<IContinuousProcess, T>
        IApplicative<IContinuousProcess>.Pure<T>(T t)
        => t.ToContinuousProcess();

    static ITypeConstructor<IContinuousProcess, T3>
        IApplicative<IContinuousProcess>.Lift<T1, T2, T3>(
            ITypeConstructor<IContinuousProcess, T1> left,
            ITypeConstructor<IContinuousProcess, T2> right,
            Func<T1, T2, T3> combinator)
        => Process.Lift(
            left.ToContinuousProcess(),
            right.ToContinuousProcess(),
            combinator);

    static IMaybe<T> Trait.IObservable<IContinuousProcess>.Observe<T>(
        ITypeConstructor<IContinuousProcess, T> observable,
        DateTime t)
        => observable
            .ToContinuousProcess()
            .Observe(t);
}