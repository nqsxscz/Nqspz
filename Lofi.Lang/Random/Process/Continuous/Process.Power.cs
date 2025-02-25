using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Power<T, TNatural>(
        this IProcess<T> left, 
        IProcess<TNatural> right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => Lift(
            left, 
            right, 
            Group.Power);
    
    public static IProcess<T> Power<T>(
        this IProcess<T> left, 
        IProcess<T> right)
        where T : IReal<T>
        => Lift(
            left, 
            right, 
            Real.Power);
}