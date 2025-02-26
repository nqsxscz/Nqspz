using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Negate<T>(
        this IPiecewiseConstantContinuousProcess<T> operand)
        where T : IAdditiveGroup<T>
        => operand
            .Select(
                Group.Negate);
}