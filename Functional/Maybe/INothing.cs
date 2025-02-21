namespace Functional.Maybe;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface INothing<out T> 
    : IMaybe<T>;