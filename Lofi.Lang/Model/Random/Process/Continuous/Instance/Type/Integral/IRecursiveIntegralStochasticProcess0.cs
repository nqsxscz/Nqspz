using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Integral;

public interface IRecursiveIntegralStochasticProcess0<T>
    : IIntegralStochasticProcess<T>
    where T : 
        IAdditiveGroup<T>,
        IMultiplicativeSemigroup<T>
{
    Func<T, T> Function { get; }
    
    IDifferentialStochasticProcess<T> Integrator { get; }
}