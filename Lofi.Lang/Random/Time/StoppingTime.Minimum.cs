using Lofi.Lang.Random.Time.Instance;
using Lofi.Lang.Random.Time.Instance.Implementation;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    private static IStoppingTime Minimum(
        this IStoppingTime left,
        IStoppingTime right)
        => new MinimumStoppingTime(
            left,
            right);
}