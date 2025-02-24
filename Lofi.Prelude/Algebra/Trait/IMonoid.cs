namespace Lofi.Prelude.Algebra.Trait;

public interface IMonoid<T>
    : ISemigroup<T>
    where T : notnull, IMonoid<T>
{
    static abstract T Identity { get; }
}