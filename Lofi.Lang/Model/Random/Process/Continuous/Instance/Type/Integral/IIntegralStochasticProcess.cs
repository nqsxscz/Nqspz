using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Integral;

public interface IIntegralStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : 
        IAdditiveGroup<T>,
        IMultiplicativeSemigroup<T>;