using Lofi.Prelude.Data.Instance.Maybe;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance;

public interface IProcess<out T>
    : ITypeConstructor<IProcess, T>
    where T : notnull
{
    IMaybe<T> Observe(DateTime t);
}