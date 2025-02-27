using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Wiener;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Wiener;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IWienerStochasticProcess<T> Wiener<T>()
        where T : IReal<T>
        => new WienerStochasticProcess<T>();
}