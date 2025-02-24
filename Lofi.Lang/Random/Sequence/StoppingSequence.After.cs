using Lofi.Lang.Random.Sequence.Instance;
using Lofi.Lang.Random.Sequence.Instance.Implementation;
using Lofi.Lang.Random.Sequence.Operator;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IStoppingSequence After(
        this IStoppingSequence left,
        IStoppingSequence right)
        => new BinaryOperationStoppingSequence
            <IAfterBinaryOperator>(
                left,
                right);
}