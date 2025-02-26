using Lofi.Prelude.Data.Instance.Identity.Implementation;
using Lofi.Prelude.Data.Instance.Identity.Type;
using Lofi.Prelude.Data.Instance.Identity.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data;

public static class Identity
{
    public static IIdentity<T> Of<T>(
        T value)
        where T : notnull
        => new Identity<T>(value);
    
    public static IIdentity<T> ToIdentity<T>(
        this ITypeConstructor<IIdentity, T> maybe)
        where T : notnull
        => (IIdentity<T>)maybe;

    public static IIdentity<T> ToIdentity<T>(
        this T value)
        where T : notnull
        => Of(value);
}