using Lofi.Lang.Random.Temporal.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Empty<T>()
        where T : notnull
        => new EmptyTemporal<T>();
}