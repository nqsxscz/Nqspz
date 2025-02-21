namespace Functional.List;

/// <summary>
/// 
/// </summary>
public static class List
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IList<T> Empty<T>()
        where T : notnull
        => new Nil<T>();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IList<T> Of<T>(T item)
        where T : notnull
        => Empty<T>()
            .Append(item);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="list"></param>
    /// <param name="item"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IList<T> Append<T>(
        IList<T> list, 
        T item)
        where T : notnull
        => new Append<T>(
            list,
            item);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IList<T> Append<T>(
        T item,
        IList<T> list)
        where T : notnull
        => Append(
            list, 
            item);
}