using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record SupplierStoppedProcess<T>(
    ISupplier<T> Supplier,
    string Key) :
    ISupplierStoppedProcess<T>
    where T : notnull;