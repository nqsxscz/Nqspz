using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Integral;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Integral;

internal sealed record RecursiveIntegralStochasticProcess0<T>(
    Func<T, T> Function,
    IDifferentialStochasticProcess<T> Integrator)
    : IRecursiveIntegralStochasticProcess0<T>
    where T : 
        IAdditiveGroup<T>,
        IMultiplicativeSemigroup<T>;