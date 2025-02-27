using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Time;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<DateTime> Time
        => new TimeStochasticProcess();
}