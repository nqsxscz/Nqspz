using Lofi.Lang.Random.Sequence.Instance.Operator;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Sequence.Instance.Implementation;

internal sealed record BinaryOperationStoppingSequence(
    IStoppingSequence Left,
    IStoppingSequence Right,
    IOperator Operator)
    : IBinaryOperationStoppingSequence;