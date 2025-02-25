using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface IConstantProcess<out T>
    : IProcess<T>
    where T : notnull
{
    T Value { get; }

    IMaybe<T> IProcess<T>.Observe(DateTime t)
        => Value.ToMaybe();
}