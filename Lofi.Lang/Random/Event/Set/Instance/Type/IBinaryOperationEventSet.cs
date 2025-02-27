using Lofi.Lang.Random.Event.Set.Instance.Operator;

namespace Lofi.Lang.Random.Event.Set.Instance.Type;

public interface IBinaryOperationEventSet
    : IEventSet
{
    IEventSet Left { get; }

    IEventSet Right { get; }
    
    IOperator Operator { get; }
}