using Lofi.Lang.Observable.Event.Set.Instance.Implementation;
using Lofi.Lang.Observable.Event.Set.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set;

public static partial class EventSet
{
    public static IEventSet Except(this 
        IEventSet left,
        IEventSet right)
        => new BinaryOperationEventSet(
                left,
                right,
                Operator.Except);
}