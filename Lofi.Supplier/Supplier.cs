using Lofi.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lofi.Supplier;

public static class Supplier
{
    public static Func<DateTime, IMaybe<T>> 
        Ask<T>(
            this ISupplier<T> supplier, 
            string key)
        where T : notnull
        => t
            => supplier
                .Ask(key, t);
}