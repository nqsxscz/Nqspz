using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Sequence;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface ISupplierStoppedProcess<out T> :
    IStoppedProcess<T>
    where T : notnull
{
    ISupplier<T> Supplier { get; }

    string Key { get; }

    IStoppingSequence IStoppedProcess<T>.StoppingSequence
        => Supplier
            .Times
            .ToStoppingSequence();

    IMaybe<T> IProcess<T>.Observe(DateTime t)
        => Supplier
            .Times
            .Where(s => s <= t)
            .MaybeLast()
            .SelectMany(s => Supplier.Ask(Key, s))
            .ToMaybe();
}