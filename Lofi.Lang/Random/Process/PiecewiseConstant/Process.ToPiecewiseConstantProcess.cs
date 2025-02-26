using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.TypeConstructor;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant;

public static partial class Process
{
    public static IPiecewiseConstantContinuousProcess<T> 
        ToPiecewiseConstantProcess<T>(
            this ITypeConstructor<IPiecewiseConstantProcess, T> observable)
        where T : notnull
        => (IPiecewiseConstantContinuousProcess<T>)observable;

    public static IPiecewiseConstantContinuousProcess<T> 
        ToPiecewiseConstantProcess<T>(
            this T value)
        where T : notnull
        => Of(value);

    public static IPiecewiseConstantContinuousProcess<T> 
        ToPiecewiseConstantProcess<T>(
            this ISupplier<T> supplier, 
            string key)
        where T : notnull
        => Of(
            supplier,
            key);
}