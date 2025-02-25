using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> One<T>()
        where T : IMultiplicativeMonoid<T>
        => T.One
            .ToStoppedProcess();
}