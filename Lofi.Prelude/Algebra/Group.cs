using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Algebra;

public static class Group
{
    public static T Invert<T>(this T value)
        where T : IGroup<T>
        => T.Invert(value);
    
    public static T Negate<T>(this T value)
        where T : IAdditiveGroup<T>
        => -value;
    
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
        => right >= TNatural.Zero ? 
            left.Power1(right) 
            : 
            left.Power1(right)
                .Invert();
    
    private static T Power1<T, TNatural>(
        this T left, 
        TNatural right)
        where T : IMultiplicativeMonoid<T>
        where TNatural : INatural<TNatural>
        => right.Equals(TNatural.Zero) ? 
            T.One : left * left.Power1(right - TNatural.One);
}