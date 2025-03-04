using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Subtract<T>(this 
        IStochasticProcess<T> left,
        IStochasticProcess<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);

    public static IStochasticProcess<T> Subtract<T>(this
        IStochasticProcess<T> left,
        T right)
        where T : IAdditiveGroup<T>
        => left.Subtract(
            right.ToStochasticProcess());
    
    public static IStochasticProcess<T> Subtract<T>(this
        T left,
        IStochasticProcess<T> right)
        where T : IAdditiveGroup<T>
        => left.ToStochasticProcess()
            .Subtract(right);
}