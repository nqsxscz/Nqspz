using Lofi.Lang.Random.Temporal.Discrete.Instance.Implementation;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Offset<T>(
        this IDiscreteTemporal<T> temporal,
        int offset)
        where T : notnull
        => new OffsetDiscreteTemporal<T>(
            temporal,
            offset);
}