using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Wiener;

internal sealed record WienerStochasticProcess<T>
    : IWienerStochasticProcess<T>
    where T : IReal<T>;