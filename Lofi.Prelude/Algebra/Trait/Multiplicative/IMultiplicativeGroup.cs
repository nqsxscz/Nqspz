namespace Lofi.Prelude.Algebra.Trait.Multiplicative;

public interface IMultiplicativeGroup<T> :
    IMultiplicativeMonoid<T>,
    IGroup<T>
    where T : IMultiplicativeGroup<T>
{
    static virtual T operator /(T left, T right)
        => left * T.Invert(right);
}