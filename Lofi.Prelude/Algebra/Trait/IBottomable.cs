namespace Lofi.Prelude.Algebra.Trait;

public interface IBottomable<out T>
    where T : notnull, IBottomable<T>
{
    static abstract T Bottom { get; }
}