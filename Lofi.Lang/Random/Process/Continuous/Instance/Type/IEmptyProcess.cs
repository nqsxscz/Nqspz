using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface IEmptyProcess<out T>
    : IProcess<T>
    where T : notnull
{
    IMaybe<T> IProcess<T>.Observe(DateTime t)
        => Maybe.Nothing<T>();
}