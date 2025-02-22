using Time.Durations.Instances;

namespace Time.Times.Instances;

/// <summary>
/// 
/// </summary>
/// <param name="DateTime"></param>
public sealed record SystemDateTime(
    DateTime DateTime) 
    : ITime<SystemDateTime, SystemTimeSpanDuration>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="time"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    public static SystemDateTime operator +(
        SystemDateTime time, 
        SystemTimeSpanDuration duration)
        => new(time.DateTime + duration.Span);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static SystemTimeSpanDuration operator -(
        SystemDateTime left, 
        SystemDateTime right)
        => new(left.DateTime - right.DateTime);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >(
        SystemDateTime left, 
        SystemDateTime right)
        => left.DateTime > right.DateTime;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator >=(
        SystemDateTime left, 
        SystemDateTime right)
        => left.DateTime >= right.DateTime;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <(
        SystemDateTime left, 
        SystemDateTime right)
        => left.DateTime < right.DateTime;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator <=(
        SystemDateTime left, 
        SystemDateTime right)
        => left.DateTime <= right.DateTime;
}