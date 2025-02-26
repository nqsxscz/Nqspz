using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Subtract<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
}