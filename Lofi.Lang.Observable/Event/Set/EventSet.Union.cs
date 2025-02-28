using Lofi.Lang.Observable.Event.Set.Instance.Implementation;
using Lofi.Lang.Observable.Event.Set.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set;

public static partial class EventSet
{
    public static IEventSet Union(this 
        IEventSet left,
        IEventSet right)
        => new BinaryOperationEventSet(
                left,
                right,
                Operator.Union);
}