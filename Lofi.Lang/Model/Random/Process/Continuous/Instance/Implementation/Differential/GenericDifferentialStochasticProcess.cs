using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Differential;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Differential;

internal sealed record GenericDifferentialStochasticProcess<T>(
    IStochasticProcess<T> Operand)
    : IGenericDifferentialStochasticProcess<T>
    where T : IAdditiveGroup<T>;