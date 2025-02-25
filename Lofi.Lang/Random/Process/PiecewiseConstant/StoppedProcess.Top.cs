using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Top<T>()
        where T : IToppable<T>
        => T.Top
            .ToStoppedProcess();
}