using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Integral;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Integrate<T>(
        IStochasticProcess<T> integrand,
        IDifferentialStochasticProcess<T> integrator)
        where T : 
        IAdditiveGroup<T>,
        IMultiplicativeSemigroup<T> 
        => Integrate(
            (_, y) => y,
            integrand,
            integrator);
    
    public static IStochasticProcess<T> Integrate<T>(
        Func<T, T> function,
        IDifferentialStochasticProcess<T> integrator)
        where T : 
            IAdditiveGroup<T>,
            IMultiplicativeSemigroup<T> 
        => Integrate(
            (x, _) => function(x),
            T.Zero.ToStochasticProcess(),
            integrator);
    
    public static IStochasticProcess<T> Integrate<T>(
        Func<T, T, T> function,
        IStochasticProcess<T> operand,
        IDifferentialStochasticProcess<T> integrator)
        where T : 
        IAdditiveGroup<T>,
        IMultiplicativeSemigroup<T> 
        => new IntegralStochasticProcess<T>(
            function, 
            operand, 
            integrator);
}