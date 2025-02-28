using Lofi.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lofi.Supplier;

public interface ISupplier<out T>
    where T : notnull
{
    IEnumerable<DateTime> Times { get; }

    IMaybe<T> Ask(string key, DateTime t);
}