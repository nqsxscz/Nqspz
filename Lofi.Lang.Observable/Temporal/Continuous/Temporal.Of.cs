using Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Of<T>(T value)
        where T : notnull
        => new ConstantTemporal<T>(value);

    public static ITemporal<T> Of<T>(Func<DateTime, T> f)
        where T : notnull
        => Time.Select(f);
}