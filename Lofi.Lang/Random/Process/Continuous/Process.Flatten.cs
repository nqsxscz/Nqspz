using Lofi.Lang.Random.Process.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IProcess<T> Flatten<T>(
        this IProcess<IMaybe<T>> process)
        where T : notnull
        => new FlattenProcess<T>(process);
}