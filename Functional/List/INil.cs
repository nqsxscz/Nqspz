namespace Functional.List;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface INil<out T> 
    : IList<T>
    where T : notnull;