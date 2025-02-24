namespace Lofi.Prelude.Algebra.Trait.Multiplicative;

public interface IMultiplicativeSemigroup<T>
    : ISemigroup<T>
    where T : notnull, IMultiplicativeSemigroup<T>
{
    static T ISemigroup<T>.Combine(T left, T right)
    {
        return left * right;
    }

    static abstract T operator *(T left, T right);
}