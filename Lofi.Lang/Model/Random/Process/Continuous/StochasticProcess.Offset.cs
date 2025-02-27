using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Offset;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Offset<T>(
        this IStochasticProcess<T> operand,
        Func<DateTime, DateTime> offsetter)
        where T : notnull
        => new OffsetStochasticProcess<T>(
            operand, 
            offsetter);
}