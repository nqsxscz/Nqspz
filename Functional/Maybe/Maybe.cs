namespace Functional.Maybe;

/// <summary>
/// 
/// </summary>
public static class Maybe
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> Nothing<T>()
        => new Nothing<T>();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IMaybe<T> Of<T>(T value)
        => new Just<T>(value);
}