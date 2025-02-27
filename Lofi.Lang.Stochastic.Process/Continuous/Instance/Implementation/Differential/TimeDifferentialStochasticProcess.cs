using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Differential;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Differential;

internal sealed record TimeDifferentialStochasticProcess<T>(
    IStochasticProcess<DateTime> Operand,
    Func<TimeSpan, T> Converter)
    : ITimeDifferentialStochasticProcess<T>
    where T : IAdditiveGroup<T>;