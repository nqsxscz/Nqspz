using Lofi.Lang.Random.Process.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T> Flatten<T>(
        this IContinuousProcess<IMaybe<T>> continuousProcess)
        where T : notnull
        => new FlattenContinuousProcess<T>(continuousProcess);
}