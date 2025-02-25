using Lofi.Lang.Random.Process.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Of<T>(T value)
        where T : notnull
        => new ConstantProcess<T>(value);

    public static IProcess<T> Of<T>(Func<DateTime, T> f)
        where T : notnull
        => Time.Select(f);
}