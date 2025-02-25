using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Divide<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : IMultiplicativeGroup<T>
        => Lift(
            left, 
            right, 
            Group.Divide);
}