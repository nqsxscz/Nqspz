using Lofi.Lang.Random.Sequence.Instance.Operator;

namespace Lofi.Lang.Random.Sequence.Instance.Implementation;

internal sealed record BinaryOperationStoppingSequence(
    IStoppingSequence Left,
    IStoppingSequence Right,
    IOperator Operator)
    : IBinaryOperationStoppingSequence;