using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Algebra;

public static class Semigroup
{
    public static T Combine<T>(this T left, T right)
        where T : ISemigroup<T>
        => T.Combine(left, right);
    
    public static T Add<T>(this T left, T right)
        where T : IAdditiveSemigroup<T>
        => left + right;
    
    public static T Multiply<T>(this T left, T right)
        where T : IMultiplicativeSemigroup<T>
        => left * right;
}