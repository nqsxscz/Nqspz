namespace Lofi.Prelude.Data.Instance.Maybe.Implementation;

/// <summary>
/// </summary>
/// <param name="Value"></param>
/// <typeparam name="T"></typeparam>
internal sealed record Just<T>(T Value)
    : IJust<T>
    where T : notnull;