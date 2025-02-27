using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Constant;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Constant;

internal sealed record ConstantStochasticProcess<T>(
    T Value)
    : IConstantStochasticProcess<T>
    where T : notnull;