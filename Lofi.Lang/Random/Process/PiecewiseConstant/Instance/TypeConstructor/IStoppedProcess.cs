using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.TypeConstructor;

public interface IStoppedProcess : Trait.IObservable<IStoppedProcess>,
    IApplicative<IStoppedProcess>
{
    static ITypeConstructor<IStoppedProcess, T2>
        IFunctor<IStoppedProcess>.Select<T1, T2>(
            ITypeConstructor<IStoppedProcess, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToStoppedProcess()
            .Select(selector);

    static ITypeConstructor<IStoppedProcess, T>
        IApplicative<IStoppedProcess>.Pure<T>(T t)
        => t.ToStoppedProcess();

    static ITypeConstructor<IStoppedProcess, T3>
        IApplicative<IStoppedProcess>.Lift<T1, T2, T3>(
            ITypeConstructor<IStoppedProcess, T1> left,
            ITypeConstructor<IStoppedProcess, T2> right,
            Func<T1, T2, T3> combinator)
        => StoppedProcess.Lift(
            left.ToStoppedProcess(),
            right.ToStoppedProcess(),
            combinator);

    static IMaybe<T> Trait.IObservable<IStoppedProcess>.Observe<T>(
        ITypeConstructor<IStoppedProcess, T> observable,
        DateTime t)
        => observable
            .ToStoppedProcess()
            .Observe(t);
}