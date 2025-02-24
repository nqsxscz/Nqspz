using Lofi.Lang.Random.Process.Continuous.Instance;
using Lofi.Lang.Random.Sequence;
using Lofi.Lang.Random.Sequence.Instance;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance;

public interface IOffsetStoppedProcess<out T> :
    IStoppedProcess<T>
    where T : notnull
{
    IStoppedProcess<T> Operand { get; }

    int Offset { get; }

    IStoppingSequence IStoppedProcess<T>.StoppingSequence
        => Operand.StoppingSequence;

    IMaybe<T> IProcess<T>.Observe(DateTime t)
        => StoppingSequence
            .Occurrences(t)
            .SkipLast(Offset)
            .MaybeLast()
            .SelectMany(Operand.Observe)
            .ToMaybe();
}