using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Wiener;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Wiener<T>()
        where T : IReal<T>
        => new WienerStochasticProcess<T>();
}