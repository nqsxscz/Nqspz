using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Subtract<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : IAdditiveGroup<T>
        => Lift(
            left, 
            right, 
            Group.Subtract);
}