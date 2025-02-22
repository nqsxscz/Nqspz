namespace Time.Durations.Instances;

/// <summary>
/// 
/// </summary>
/// <param name="Span"></param>
public sealed record SystemTimeSpanDuration(
    TimeSpan Span) 
    : IDuration<SystemTimeSpanDuration>
{
    /// <summary>
    /// 
    /// </summary>
    public static SystemTimeSpanDuration Zero
        => new(TimeSpan.Zero);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static SystemTimeSpanDuration operator +(
        SystemTimeSpanDuration left, 
        SystemTimeSpanDuration right)
        => new(left.Span + right.Span);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="operand"></param>
    /// <returns></returns>
    public static SystemTimeSpanDuration Invert(
        SystemTimeSpanDuration operand)
        => new(-operand.Span);
}