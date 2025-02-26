using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Exp<T>(
        this IProcess<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Exp);
}