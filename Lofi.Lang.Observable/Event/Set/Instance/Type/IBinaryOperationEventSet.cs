using Lofi.Lang.Observable.Event.Set.Instance.Operator;

namespace Lofi.Lang.Observable.Event.Set.Instance.Type;

public interface IBinaryOperationEventSet
    : IEventSet
{
    IEventSet Left { get; }

    IEventSet Right { get; }
    
    IOperator Operator { get; }
}