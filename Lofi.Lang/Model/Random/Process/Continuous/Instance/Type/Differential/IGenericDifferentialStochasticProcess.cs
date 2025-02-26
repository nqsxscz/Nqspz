using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;

public interface IGenericDifferentialStochasticProcess<out T>
    : IDifferentialStochasticProcess<T>
    where T : IAdditiveGroup<T>
{
    IStochasticProcess<T> Operand { get; }
}