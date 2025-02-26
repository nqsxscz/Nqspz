using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Integral;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Integral;

internal sealed record RecursiveIntegralStochasticProcess1<T>(
    Func<T, T, T> Function,
    IStochasticProcess<T> Operand,
    IDifferentialStochasticProcess<T> Integrator)
    : IRecursiveIntegralStochasticProcess1<T>
    where T : 
        IAdditiveGroup<T>,
        IMultiplicativeSemigroup<T>;