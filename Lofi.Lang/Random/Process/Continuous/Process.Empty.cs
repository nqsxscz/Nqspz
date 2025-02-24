using Lofi.Lang.Random.Process.Continuous.Instance;
using Lofi.Lang.Random.Process.Continuous.Instance.Implementation;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Empty<T>()
        where T : notnull
        => new EmptyProcess<T>();
}