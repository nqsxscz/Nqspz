namespace Functional.List;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAppend<out T>
    : IList<T>
    where T : notnull
{
    /// <summary>
    /// 
    /// </summary>
    IList<T> Head { get; }
    
    /// <summary>
    /// 
    /// </summary>
    T Tail { get; }
}