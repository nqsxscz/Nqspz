using Lofi.Lang.Random.Sequence.Instance;
using Lofi.Lang.Random.Sequence.Instance.Implementation;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IStoppingSequence Take(
        this IStoppingSequence operand,
        int count)
        => new TakeStoppingSequence(
            operand,
            count);
}