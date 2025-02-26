using Lofi.Lang.Random.Process.Continuous;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> Of<T>(
        T value)
        where T : notnull
        => value
            .ToContinuousProcess()
            .Discretize(Sequence.StoppingSequence.Empty);

    public static IPiecewiseConstantContinuousProcess<T> Of<T>(
        ISupplier<T> supplier,
        string key)
        where T : notnull
        => new SupplierPiecewiseConstantContinuousProcess<T>(
            supplier,
            key);
}