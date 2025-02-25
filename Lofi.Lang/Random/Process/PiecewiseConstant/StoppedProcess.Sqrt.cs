using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Sqrt<T>(
        this IStoppedProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Sqrt);
}