using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Abs<T>(
        this IContinuousProcess<T> operand)
        where T : 
            IAdditiveGroup<T>,
            IOrderable<T>
        => operand
            .Select(
                Group.Abs);
}