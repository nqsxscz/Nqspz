namespace Functional.List;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
internal sealed record Nil<T> 
    : INil<T>
    where T : notnull;