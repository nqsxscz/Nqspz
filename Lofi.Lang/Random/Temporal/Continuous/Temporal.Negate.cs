using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Negate<T>(
        this ITemporal<T> operand)
        where T : IAdditiveGroup<T>
        => operand
            .Select(
                Group.Negate);
}