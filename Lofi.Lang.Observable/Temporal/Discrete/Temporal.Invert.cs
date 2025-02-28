using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Invert<T>(
        this IDiscreteTemporal<T> operand)
        where T : IMultiplicativeGroup<T>
        => operand
            .Select(
                T.Invert);
}