namespace Lofi.Prelude.Data.Instance.Maybe;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IJust<out T>
    : IMaybe<T>
    where T : notnull
{
    /// <summary>
    /// </summary>
    T Value { get; }
}