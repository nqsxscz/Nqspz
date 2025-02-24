using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe;

namespace Lofi.Lang.Random.Process.Continuous.Instance;

public interface IConstantProcess<out T>
    : IProcess<T>
    where T : notnull
{
    T Value { get; }

    IMaybe<T> IProcess<T>.Observe(DateTime t)
        => Value.ToMaybe();
}