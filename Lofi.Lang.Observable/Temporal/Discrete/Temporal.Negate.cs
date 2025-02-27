using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Negate<T>(
        this IDiscreteTemporal<T> operand)
        where T : IAdditiveGroup<T>
        => operand
            .Select(
                Group.Negate);
}