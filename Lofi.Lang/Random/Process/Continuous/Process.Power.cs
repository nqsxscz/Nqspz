using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Power<T, TNatural>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IContinuousProcess<T> Power<T>(
        this IContinuousProcess<T> left, 
        IContinuousProcess<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
}