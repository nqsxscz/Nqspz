using Lofi.Lang.Random.Time.Instance.Implementation;
using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    private static IStoppingTime Maximum(
        this IStoppingTime left,
        IStoppingTime right)
        => new MaximumStoppingTime(
            left, 
            right);
}