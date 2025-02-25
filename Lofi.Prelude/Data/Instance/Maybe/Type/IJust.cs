namespace Lofi.Prelude.Data.Instance.Maybe.Type;

public interface IJust<out T>
    : IMaybe<T>
    where T : notnull
{
    T Value { get; }
}