namespace Lofi.Prelude.Algebra.Trait;

public interface IGroup<T>
    : IMonoid<T>
    where T : IGroup<T>
{
    static abstract T Reciprocate(T operand);
}