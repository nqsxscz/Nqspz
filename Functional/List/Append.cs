namespace Functional.List;

/// <summary>
/// 
/// </summary>
/// <param name="Head"></param>
/// <param name="Tail"></param>
/// <typeparam name="T"></typeparam>
internal sealed record Append<T>(
    IList<T> Head, 
    T Tail) 
    : IAppend<T>
    where T : notnull;