using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Divide<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
}