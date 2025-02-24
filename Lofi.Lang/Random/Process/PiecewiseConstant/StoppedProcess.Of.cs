using Lofi.Lang.Random.Process.Continuous;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Implementation;
using Lofi.Lang.Random.Sequence;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> Of<T>(
        T value)
        where T : notnull
        => value
            .ToProcess()
            .Discretize(StoppingSequence.Empty);

    public static IStoppedProcess<T> Of<T>(
        ISupplier<T> supplier,
        string key)
        where T : notnull
        => new SupplierStoppedProcess<T>(
            supplier,
            key);
}