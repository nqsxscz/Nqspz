using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.TypeConstructor;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> 
        ToDiscreteTemporal<T>(
            this ITypeConstructor<IDiscreteTemporal, T> observable)
        where T : notnull
        => (IDiscreteTemporal<T>)observable;

    public static IDiscreteTemporal<T> 
        ToDiscreteTemporal<T>(
            this T value)
        where T : notnull
        => Of(value);

    public static IDiscreteTemporal<T> 
        ToDiscreteTemporal<T>(
            this ISupplier<T> supplier, 
            string key)
        where T : notnull
        => Of(
            supplier,
            key);
}