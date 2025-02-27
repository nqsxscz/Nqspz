using Lofi.Lang.Random.Temporal.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Offset<T>(
        this ITemporal<T> operand,
        TimeSpan offset)
        where T : notnull
        => operand
            .Offset(
                offset, 
                (t, dt) 
                    => t - dt);
    
    public static ITemporal<T> Offset<T>(
        this ITemporal<T> operand,
        TimeSpan offset,
        Func<DateTime, TimeSpan, DateTime> offsetter)
        where T : notnull
        => new OffsetTemporal<T>(
            operand,
            offset,
            offsetter);
}