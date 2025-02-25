using Lofi.Lang.Random.Time.Instance.Type;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    public static Func<IStoppingTime, bool>
        Occurred(DateTime t)
        => stoppingTime 
            => stoppingTime
                .Occurred(t);

    public static bool Occurred(
        this IStoppingTime stoppingTime,
        DateTime t)
        => stoppingTime
            .Occurrence(t)
            .IsNotEmpty();
}