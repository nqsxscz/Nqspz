using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Exp<T>(
        this IDiscreteTemporal<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Exp);
}