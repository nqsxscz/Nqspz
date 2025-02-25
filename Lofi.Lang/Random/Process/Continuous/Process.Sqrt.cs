using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Sqrt<T>(
        this IProcess<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Sqrt);
}