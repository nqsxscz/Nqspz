using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Invert<T>(
        this ITemporal<T> operand)
        where T : IMultiplicativeGroup<T>
        => operand
            .Select(
                T.Invert);
}