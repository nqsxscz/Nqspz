using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Zero<T>()
        where T : IAdditiveMonoid<T>
        => T.Zero
            .ToProcess();
}