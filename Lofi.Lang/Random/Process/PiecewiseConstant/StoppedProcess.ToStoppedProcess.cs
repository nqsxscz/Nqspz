using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class StoppedProcess
{
    public static IStoppedProcess<T> ToStoppedProcess<T>(
        this ITypeConstructor<IStoppedProcess, T> observable)
        where T : notnull
        => (IStoppedProcess<T>)observable;

    public static IStoppedProcess<T> ToStoppedProcess<T>(
        this T value)
        where T : notnull
        => Of(value);

    public static IStoppedProcess<T> ToStoppedProcess<T>(
        this ISupplier<T> supplier,
        string key)
        where T : notnull
        => Of(
            supplier,
            key);
}