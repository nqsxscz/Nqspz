using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Sequence;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface IDiscretizedStoppedProcess<out T> :
    IStoppedProcess<T>
    where T : notnull
{
    IProcess<T> Operand { get; }

    IMaybe<T> IProcess<T>.Observe(DateTime t)
        => StoppingSequence
            .Occurrences(t)
            .MaybeLast()
            .SelectMany(Operand.Observe)
            .ToMaybe();
}