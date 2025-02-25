using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Negate<T>(
        this IProcess<T> operand)
        where T : IAdditiveGroup<T>
        => operand
            .Select(
                Group.Negate);
}