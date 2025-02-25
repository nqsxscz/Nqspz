using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Bottom<T>()
        where T : IBottomable<T>
        => T.Bottom
            .ToStoppedProcess();
}