using Lofi.Lang.Observable.Event.Set.Instance.Implementation;
using Lofi.Lang.Observable.Event.Set.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set;

public static partial class EventSet
{
    public static IEventSet Take(this 
        IEventSet operand,
        int count)
        => new TakeEventSet(
            operand,
            count);
}