using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Top<T>()
        where T : IToppable<T>
        => T.Top
            .ToProcess();
}