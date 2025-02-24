using Lofi.Lang.Random.Sequence.Operator;

namespace Lofi.Lang.Random.Sequence.Instance.Implementation;

internal sealed record BinaryOperationStoppingSequence<TOperator>(
    IStoppingSequence Left,
    IStoppingSequence Right)
    : IBinaryOperationStoppingSequence<TOperator>
    where TOperator : IBinaryOperator;