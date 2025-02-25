using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Algebra;

public static class Semigroup
{
    public static T Combine<T>(T left, T right)
        where T : notnull, ISemigroup<T>
        => T.Combine(left, right);
    
    public static T Add<T>(T left, T right)
        where T : notnull, IAdditiveSemigroup<T>
        => left + right;
    
    public static T Multiply<T>(T left, T right)
        where T : notnull, IMultiplicativeSemigroup<T>
        => left * right;
}