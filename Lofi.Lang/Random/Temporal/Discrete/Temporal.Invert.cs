using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Invert<T>(
        this IDiscreteTemporal<T> operand)
        where T : IGroup<T>
        => operand
            .Select(
                T.Invert);
}