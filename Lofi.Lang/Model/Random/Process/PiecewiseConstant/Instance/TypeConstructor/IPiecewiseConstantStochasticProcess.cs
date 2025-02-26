using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.TypeConstructor;

public interface IPiecewiseConstantStochasticProcess
    : IApplicative<IPiecewiseConstantStochasticProcess>
{
    static ITypeConstructor<IPiecewiseConstantStochasticProcess, T2>
        IFunctor<IPiecewiseConstantStochasticProcess>.Select<T1, T2>(
            ITypeConstructor<IPiecewiseConstantStochasticProcess, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToPiecewiseConstantStochasticProcess()
            .Select(selector);

    static ITypeConstructor<IPiecewiseConstantStochasticProcess, T>
        IApplicative<IPiecewiseConstantStochasticProcess>.Pure<T>(T t)
        => t.ToPiecewiseConstantStochasticProcess();

    static ITypeConstructor<IPiecewiseConstantStochasticProcess, T3>
        IApplicative<IPiecewiseConstantStochasticProcess>.Lift<T1, T2, T3>(
            ITypeConstructor<IPiecewiseConstantStochasticProcess, T1> left,
            ITypeConstructor<IPiecewiseConstantStochasticProcess, T2> right,
            Func<T1, T2, T3> combinator)
        => StochasticProcess.Lift(
            left.ToPiecewiseConstantStochasticProcess(),
            right.ToPiecewiseConstantStochasticProcess(),
            combinator);
}