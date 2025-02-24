namespace Lofi.Prelude.Data.Instance.Maybe;

/// <summary>
/// </summary>
/// <typeparam name="T"></typeparam>
public interface INothing<out T>
    : IMaybe<T>
    where T : notnull;