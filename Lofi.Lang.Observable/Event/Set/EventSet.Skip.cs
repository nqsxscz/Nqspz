using Lofi.Lang.Observable.Event.Set.Instance.Implementation;
using Lofi.Lang.Observable.Event.Set.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set;

public static partial class EventSet
{
    public static IEventSet Skip(this 
        IEventSet operand,
        int count)
        => new SkipEventSet(
            operand,
            count);
}