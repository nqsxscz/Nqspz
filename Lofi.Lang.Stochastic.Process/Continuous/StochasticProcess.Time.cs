using Lofi.Lang.Stochastic.Process.Continuous.Instance.Implementation.Time;
using Lofi.Lang.Stochastic.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<DateTime> Time
        => new TimeStochasticProcess();
}