using Lofi.Lang.Model.Random.Process.Continuous.Instance.Implementation.Offset;
using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Offset<T>(
        this IStochasticProcess<T> operand,
        TimeSpan offset,
        Func<DateTime, TimeSpan, DateTime> offsetter)
        where T : notnull
        => new OffsetStochasticProcess<T>(
            operand, 
            offset,
            offsetter);
}