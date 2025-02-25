using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Maximum<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : IOrderable<T>
        => Lift(
            left, 
            right, 
            Orderable.Maximum);
}