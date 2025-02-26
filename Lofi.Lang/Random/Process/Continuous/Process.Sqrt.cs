using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Sqrt<T>(
        this IContinuousProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Sqrt);
}