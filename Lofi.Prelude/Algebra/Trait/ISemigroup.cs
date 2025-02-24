namespace Lofi.Prelude.Algebra.Trait;

public interface ISemigroup<T>
    where T : notnull, ISemigroup<T>
{
    static abstract T Combine(T left, T right);
}