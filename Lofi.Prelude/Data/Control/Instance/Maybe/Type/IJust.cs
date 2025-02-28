namespace Lofi.Prelude.Data.Control.Instance.Maybe.Type;

public interface IJust<out T>
    : IMaybe<T>
{
    T Value { get; }
}