using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Algebra;

public static class MultiplicativeSemigroup
{
    public static T Multiply<T>(T left, T right)
        where T : notnull, IMultiplicativeSemigroup<T>
    {
        return left * right;
    }
}