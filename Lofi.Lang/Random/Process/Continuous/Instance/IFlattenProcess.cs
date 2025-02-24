using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe;

namespace Lofi.Lang.Random.Process.Continuous.Instance;

public interface IFlattenProcess<out T> :
    IProcess<T>
    where T : notnull
{
    IProcess<IMaybe<T>> Operand { get; }

    IMaybe<T> IProcess<T>.Observe(DateTime t)
        => Operand
            .Observe(t)
            .Flatten()
            .ToMaybe();
}