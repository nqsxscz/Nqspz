using Lofi.Lang.Random.Sequence.Instance.Implementation;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IStoppingSequence Skip(
        this IStoppingSequence operand,
        int count)
        => new SkipStoppingSequence(
            operand,
            count);
}