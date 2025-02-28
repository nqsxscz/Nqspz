using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Algebra;

public static class Group
{
    public static T Invert<T>(this T t)
        where T : IGroup<T>
        => T.Invert(t);
    
    public static T Negate<T>(this T t)
        where T : IAdditiveGroup<T>
        => -t;

    public static T Abs<T>(this T t)
        where T :
        IAdditiveGroup<T>,
        IOrderable<T>
        => T.Maximum(
            t, 
            -t);

    public static T Subtract<T>(this T left, T right)
        where T : IAdditiveGroup<T>
        => left - right;
    
    public static T Divide<T>(this T left, T right)
        where T : IMultiplicativeGroup<T>
        => left / right;

    public static T Power<T, TNatural>(
        this T left,
        TNatural right)
        where T : IMultiplicativeGroup<T>
        where TNatural : INatural<TNatural>
        => T.Power(left, right);
}