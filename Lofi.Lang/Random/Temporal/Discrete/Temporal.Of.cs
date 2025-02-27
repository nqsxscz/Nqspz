using Lofi.Lang.Random.Temporal.Continuous;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Implementation;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Temporal.Discrete;

public static partial class Temporal
{
    public static IDiscreteTemporal<T> Of<T>(
        T value)
        where T : notnull
        => value
            .ToTemporal()
            .Discretize(Event.Set.EventSet.Empty);

    public static IDiscreteTemporal<T> Of<T>(
        ISupplier<T> supplier,
        string key)
        where T : notnull
        => new SupplierDiscreteTemporal<T>(
            supplier,
            key);
}