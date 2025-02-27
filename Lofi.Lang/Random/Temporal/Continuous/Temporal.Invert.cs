using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Invert<T>(
        this ITemporal<T> operand)
        where T : IGroup<T>
        => operand
            .Select(
                Group.Invert);
}