namespace Lofi.Prelude.Algebra.Trait;

public interface IGroup<T>
    : IMonoid<T>
    where T : notnull, IGroup<T>
{
    static abstract T Invert(T operand);
}