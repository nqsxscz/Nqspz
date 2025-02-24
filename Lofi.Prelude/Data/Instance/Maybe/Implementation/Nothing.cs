namespace Lofi.Prelude.Data.Instance.Maybe.Implementation;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
internal sealed record Nothing<T>
    : INothing<T>
    where T : notnull;