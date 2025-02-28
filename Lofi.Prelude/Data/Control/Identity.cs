using Lofi.Prelude.Data.Control.Instance.Identity.Implementation;
using Lofi.Prelude.Data.Control.Instance.Identity.Type;
using Lofi.Prelude.Data.Control.Instance.Identity.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Control;

public static class Identity
{
    public static IIdentity<T> Of<T>(
        T t)
        where T : notnull
        => new Identity<T>(t);
    
    public static IIdentity<T> ToIdentity<T>(
        this T t)
        where T : notnull
        => Of(t);
    
    public static IIdentity<T> ToIdentity<T>(
        this ITypeConstructor<IIdentity, T> identity)
        where T : notnull
        => (IIdentity<T>)identity;
}