using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Algebra;

public static class Semigroup
{
    public static T Add<T>(this T left, T right)
        where T : IAdditiveSemigroup<T>
        => left + right;
    
    public static T Multiply<T>(this T left, T right)
        where T : IMultiplicativeSemigroup<T>
        => left * right;
    
    public static T Square<T>(this T t)
        where T : IMultiplicativeSemigroup<T>
        => t * t;
}