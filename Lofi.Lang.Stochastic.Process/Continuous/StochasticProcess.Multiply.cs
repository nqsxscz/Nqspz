using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Multiply<T>(this 
        IStochasticProcess<T> left,
        IStochasticProcess<T> right)
        where T : IMultiplicativeSemigroup<T>
        => Lift(
            left, 
            right, 
            Semigroup.Multiply);
}