using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Invert<T>(
        this IStoppedProcess<T> operand)
        where T : IGroup<T>
        => operand
            .Select(
                T.Invert);
}