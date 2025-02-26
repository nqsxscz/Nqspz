using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;

internal sealed record SupplierPiecewiseConstantContinuousProcess<T>(
    ISupplier<T> Supplier,
    string Key) :
    ISupplierPiecewiseConstantContinuousProcess<T>
    where T : notnull;