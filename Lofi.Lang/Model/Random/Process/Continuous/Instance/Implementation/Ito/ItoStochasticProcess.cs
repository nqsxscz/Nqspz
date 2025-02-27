using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Ito;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Ito;

internal sealed record ItoStochasticProcess<T>(
    T Init,
    Func<T, T, T> Drift,
    Func<T, T, T> Volatility,
    Func<TimeSpan, T> Converter,
    IStochasticProcess<T> Left,
    IStochasticProcess<T> Right,
    IStochasticProcess<T> Wiener)
    : IItoStochasticProcess<T>
    where T : 
        IAdditiveGroup<T>,
        IMultiplicativeSemigroup<T>;