namespace Functional.Maybe;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IJust<out T> 
    : IMaybe<T>
{
    /// <summary>
    /// 
    /// </summary>
    T Value { get; }
}