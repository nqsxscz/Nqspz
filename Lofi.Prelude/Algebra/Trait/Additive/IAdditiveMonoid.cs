namespace Lofi.Prelude.Algebra.Trait.Additive;

public interface IAdditiveMonoid<T> :
    IAdditiveSemigroup<T>,
    IMonoid<T>
    where T : IAdditiveMonoid<T>
{
    static abstract T Zero { get; }

    static T IMonoid<T>.Identity
        => T.Zero;
}