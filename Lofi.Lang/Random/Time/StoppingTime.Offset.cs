using Lofi.Lang.Random.Time.Instance;
using Lofi.Lang.Random.Time.Instance.Implementation;

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