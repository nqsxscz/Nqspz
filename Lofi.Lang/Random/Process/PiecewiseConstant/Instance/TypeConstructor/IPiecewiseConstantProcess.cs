using Lofi.Lang.Random.Process.Continuous;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.TypeConstructor;

public interface IPiecewiseConstantProcess : Trait.IObservable<IPiecewiseConstantProcess>,
    IApplicative<IPiecewiseConstantProcess>
{
    static ITypeConstructor<IPiecewiseConstantProcess, T2>
        IFunctor<IPiecewiseConstantProcess>.Select<T1, T2>(
            ITypeConstructor<IPiecewiseConstantProcess, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToPiecewiseConstantProcess()
            .Select(selector);

    static ITypeConstructor<IPiecewiseConstantProcess, T>
        IApplicative<IPiecewiseConstantProcess>.Pure<T>(T t)
        => t.ToPiecewiseConstantProcess();

    static ITypeConstructor<IPiecewiseConstantProcess, T3>
        IApplicative<IPiecewiseConstantProcess>.Lift<T1, T2, T3>(
            ITypeConstructor<IPiecewiseConstantProcess, T1> left,
            ITypeConstructor<IPiecewiseConstantProcess, T2> right,
            Func<T1, T2, T3> combinator)
        => Process.Lift(
            left.ToPiecewiseConstantProcess(),
            right.ToPiecewiseConstantProcess(),
            combinator);

    static IMaybe<T> Trait.IObservable<IPiecewiseConstantProcess>.Observe<T>(
        ITypeConstructor<IPiecewiseConstantProcess, T> observable,
        DateTime t)
        => observable
            .ToPiecewiseConstantProcess()
            .Observe(t);
}