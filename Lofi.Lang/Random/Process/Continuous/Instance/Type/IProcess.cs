using Lofi.Lang.Random.Process.Continuous.Instance.TypeConstructor;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface IProcess<out T>
    : ITypeConstructor<IProcess, T>
    where T : notnull
{
    IMaybe<T> Observe(DateTime t);
}