using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Maximum<T>(this 
        IStochasticProcess<T> left,
        IStochasticProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            T.Maximum);

    public static IStochasticProcess<T> Maximum<T>(this
        IStochasticProcess<T> left,
        T right)
        where T : IOrderable<T>
        => left.Maximum(
            right.ToStochasticProcess());
    
    public static IStochasticProcess<T> Maximum<T>(this
        T left,
        IStochasticProcess<T> right)
        where T : IOrderable<T>
        => left.ToStochasticProcess()
            .Maximum(right);
}