using Lofi.Lang.Observable.Event.Set.Instance.Operator;
using Lofi.Lang.Observable.Event.Set.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set.Instance.Implementation;

internal sealed record BinaryOperationEventSet(
    IEventSet Left,
    IEventSet Right,
    IOperator Operator)
    : IBinaryOperationEventSet;