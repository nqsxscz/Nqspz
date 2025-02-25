using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Invert<T>(
        this IProcess<T> operand)
        where T : IGroup<T>
        => operand
            .Select(
                Group.Invert);
}