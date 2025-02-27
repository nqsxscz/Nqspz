using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> ToTemporal<T>(
        this ITypeConstructor<ITemporal, T> observable)
        where T : notnull
        => (ITemporal<T>)observable;

    public static ITemporal<T> ToTemporal<T>(
        this T value)
        where T : notnull
        => Of(value);

    public static ITemporal<T> ToTemporal<T>(
        this Func<DateTime, T> f)
        where T : notnull
        => Of(f);
}