namespace Lofi.Prelude.Algebra.Trait;

public interface IMonoid<T>
    : ISemigroup<T>
    where T : IMonoid<T>
{
    static abstract T Identity { get; }
}