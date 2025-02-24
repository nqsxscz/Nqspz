namespace Lofi.Prelude.Algebra.Trait.Multiplicative;

public interface IMultiplicativeMonoid<T> :
    IMultiplicativeSemigroup<T>,
    IMonoid<T>
    where T : notnull, IMultiplicativeMonoid<T>
{
    static abstract T One { get; }

    static T IMonoid<T>.Identity
        => T.One;
}