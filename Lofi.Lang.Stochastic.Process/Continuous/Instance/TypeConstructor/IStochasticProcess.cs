using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.TypeConstructor;

public interface IStochasticProcess :
    IApplicative<IStochasticProcess>
{
    static ITypeConstructor<IStochasticProcess, T2>
        IFunctor<IStochasticProcess>.Select<T1, T2>(
            ITypeConstructor<IStochasticProcess, T1> operand,
            Func<T1, T2> selector)
        => operand
            .ToStochasticProcess()
            .Select(selector);

    static ITypeConstructor<IStochasticProcess, T>
        IApplicative<IStochasticProcess>.Pure<T>(T t)
        => t.ToStochasticProcess();

    static ITypeConstructor<IStochasticProcess, T3>
        IApplicative<IStochasticProcess>.Lift<T1, T2, T3>(
            ITypeConstructor<IStochasticProcess, T1> left,
            ITypeConstructor<IStochasticProcess, T2> right,
            Func<T1, T2, T3> combinator)
        => StochasticProcess.Lift(
            left.ToStochasticProcess(),
            right.ToStochasticProcess(),
            combinator);
}