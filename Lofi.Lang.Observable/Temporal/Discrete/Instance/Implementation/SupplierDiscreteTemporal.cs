using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Observable.Temporal.Discrete.Instance.Implementation;

internal sealed record SupplierDiscreteTemporal<T>(
    ISupplier<T> Supplier,
    string Key) :
    ISupplierDiscreteTemporal<T>
    where T : notnull;