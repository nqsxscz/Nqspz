using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Pi<T>()
        where T : IRealFunctions<T>
        => T.Pi
            .ToContinuousProcess();
}