using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Invert<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IGroup<T>
        => operand
            .Select(
                T.Invert);
}