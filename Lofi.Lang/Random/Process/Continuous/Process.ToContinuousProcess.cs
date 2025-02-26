using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Continuous.Instance.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> ToContinuousProcess<T>(
        this ITypeConstructor<IContinuousProcess, T> observable)
        where T : notnull
        => (IContinuousProcess<T>)observable;

    public static IContinuousProcess<T> ToContinuousProcess<T>(
        this T value)
        where T : notnull
        => Of(value);

    public static IContinuousProcess<T> ToContinuousProcess<T>(
        this Func<DateTime, T> f)
        where T : notnull
        => Of(f);
}