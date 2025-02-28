using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Add<T>(this 
        IStochasticProcess<T> left,
        IStochasticProcess<T> right)
        where T : IAdditiveSemigroup<T>
        => Lift(
            left, 
            right, 
            Semigroup.Add);
}