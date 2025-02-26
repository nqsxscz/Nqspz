using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Sqrt<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Sqrt);
}