namespace Functional.Maybe;

/// <summary>
/// 
/// </summary>
/// <param name="Value"></param>
/// <typeparam name="T"></typeparam>
public sealed record Just<T>(T Value) 
    : IJust<T>
    where T : notnull;