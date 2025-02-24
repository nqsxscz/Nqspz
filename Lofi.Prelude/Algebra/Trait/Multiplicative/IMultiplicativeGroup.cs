namespace Lofi.Prelude.Algebra.Trait.Multiplicative;

public interface IMultiplicativeGroup<T> :
    IMultiplicativeMonoid<T>,
    IGroup<T>
    where T : notnull, IMultiplicativeGroup<T>;