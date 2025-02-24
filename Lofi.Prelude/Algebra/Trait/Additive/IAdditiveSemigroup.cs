namespace Lofi.Prelude.Algebra.Trait.Additive;

public interface IAdditiveSemigroup<T>
    : ISemigroup<T>
    where T : notnull, IAdditiveSemigroup<T>
{
    static T ISemigroup<T>.Combine(T left, T right)
    {
        return left + right;
    }

    static abstract T operator +(T left, T right);
}