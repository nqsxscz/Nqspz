namespace Lofi.Prelude.Algebra.Trait.Additive;

public interface IAdditiveSemigroup<T>
    : ISemigroup<T>
    where T : notnull, IAdditiveSemigroup<T>
{
    static abstract T operator +(T left, T right);
    
    static T ISemigroup<T>.Combine(T left, T right)
        => left + right;
}