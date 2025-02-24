using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Instance.Maybe;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance;

public interface IProcess : Trait.IObservable<IProcess>,
    IApplicative<IProcess>
{
    static ITypeConstructor<IProcess, T2>
        IFunctor<IProcess>.Select<T1, T2>(
            ITypeConstructor<IProcess, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToProcess()
            .Select(selector);

    static ITypeConstructor<IProcess, T>
        IApplicative<IProcess>.Pure<T>(T t)
        => t.ToProcess();

    static ITypeConstructor<IProcess, T3>
        IApplicative<IProcess>.Lift<T1, T2, T3>(
            ITypeConstructor<IProcess, T1> left,
            ITypeConstructor<IProcess, T2> right,
            Func<T1, T2, T3> combinator)
        => Process.Lift(
            left.ToProcess(),
            right.ToProcess(),
            combinator);

    static IMaybe<T> Trait.IObservable<IProcess>.Observe<T>(
        ITypeConstructor<IProcess, T> observable,
        DateTime t)
        => observable
            .ToProcess()
            .Observe(t);
}