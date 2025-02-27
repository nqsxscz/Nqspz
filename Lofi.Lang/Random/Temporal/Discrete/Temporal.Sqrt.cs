using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Sqrt<T>(
        this IDiscreteTemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Sqrt);
}