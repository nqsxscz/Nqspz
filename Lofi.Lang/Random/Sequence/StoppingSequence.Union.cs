using Lofi.Lang.Random.Sequence.Instance;
using Lofi.Lang.Random.Sequence.Instance.Implementation;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IStoppingSequence Union(
        this IStoppingSequence left,
        IStoppingSequence right)
        => new BinaryOperationStoppingSequence(
                left,
                right,
                Operator.Union);
}