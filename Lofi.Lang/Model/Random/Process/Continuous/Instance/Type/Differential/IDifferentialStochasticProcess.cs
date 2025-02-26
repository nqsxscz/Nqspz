using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;

public interface IDifferentialStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : IAdditiveGroup<T>;