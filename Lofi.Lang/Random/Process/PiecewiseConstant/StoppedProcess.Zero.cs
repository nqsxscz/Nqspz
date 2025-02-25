using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Zero<T>()
        where T : IAdditiveMonoid<T>
        => T.Zero
            .ToStoppedProcess();
}