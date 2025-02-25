namespace Lofi.Prelude.Algebra.Trait;

public interface IToppable<out T>
    where T : notnull, IToppable<T>
{
    static abstract T Top { get; }
}