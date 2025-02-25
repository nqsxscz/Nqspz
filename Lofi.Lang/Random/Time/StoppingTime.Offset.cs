using Lofi.Lang.Random.Time.Instance.Implementation;
using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    public static IStoppingTime Offset(
        this IStoppingTime operand,
        TimeSpan offset)
        => new OffsetStoppingTime(
            operand,
            offset);
}