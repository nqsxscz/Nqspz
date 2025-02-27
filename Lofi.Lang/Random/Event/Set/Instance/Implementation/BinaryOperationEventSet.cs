using Lofi.Lang.Random.Event.Set.Instance.Operator;
using Lofi.Lang.Random.Event.Set.Instance.Type;

namespace Lofi.Lang.Random.Event.Set.Instance.Implementation;

internal sealed record BinaryOperationEventSet(
    IEventSet Left,
    IEventSet Right,
    IOperator Operator)
    : IBinaryOperationEventSet;