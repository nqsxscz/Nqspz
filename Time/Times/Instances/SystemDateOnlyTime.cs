using Time.Durations.Instances;

namespace Time.Times.Instances;

/// <summary>
/// 
/// </summary>
/// <param name="Date"></param>
public sealed record SystemDateOnlyTime(
    DateOnly Date) 
    : ITime<SystemDateOnlyTime, SystemTimeSpanDuration>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="time"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    public static SystemDateOnlyTime operator +(
        SystemDateOnlyTime time, 
        SystemTimeSpanDuration duration)
        => new(
            DateOnly.FromDateTime(
                time.Date
                    .ToDateTime(TimeOnly.MinValue) 
                + duration.Span));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static SystemTimeSpanDuration operator -(
        SystemDateOnlyTime left, 
        SystemDateOnlyTime right)
        => new(
            left.Date
                .ToDateTime(TimeOnly.MinValue) 
            - right.Date
                .ToDateTime(TimeOnly.MinValue));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(
        SystemDateOnlyTime left, 
        SystemDateOnlyTime right)
        => left.Date > right.Date;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(
        SystemDateOnlyTime left, 
        SystemDateOnlyTime right)
        => left.Date >= right.Date;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(
        SystemDateOnlyTime left, 
        SystemDateOnlyTime right)
        => left.Date < right.Date;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(
        SystemDateOnlyTime left, 
        SystemDateOnlyTime right)
        => left.Date <= right.Date;
}