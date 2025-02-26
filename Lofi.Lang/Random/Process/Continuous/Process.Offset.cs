using Lofi.Lang.Random.Process.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Offset<T>(
        this IContinuousProcess<T> operand,
        TimeSpan offset)
        where T : notnull
        => operand
            .Offset(
                offset, 
                (t, dt) 
                    => t - dt);
    
    public static IContinuousProcess<T> Offset<T>(
        this IContinuousProcess<T> operand,
        TimeSpan offset,
        Func<DateTime, TimeSpan, DateTime> offsetter)
        where T : notnull
        => new OffsetContinuousProcess<T>(
            operand,
            offset,
            offsetter);
}