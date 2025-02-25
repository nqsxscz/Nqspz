using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Continuous.Instance.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> ToProcess<T>(
        this ITypeConstructor<IProcess, T> observable)
        where T : notnull
        => (IProcess<T>)observable;

    public static IProcess<T> ToProcess<T>(
        this T value)
        where T : notnull
        => Of(value);

    public static IProcess<T> ToProcess<T>(
        this Func<DateTime, T> f)
        where T : notnull
        => Of(f);
}