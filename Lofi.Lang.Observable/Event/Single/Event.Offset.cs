using Lofi.Lang.Observable.Event.Single.Instance.Implementation;
using Lofi.Lang.Observable.Event.Single.Instance.Type;

namespace Lofi.Lang.Observable.Event.Single;

public static partial class Event
{
    public static IEvent Offset(this 
        IEvent operand,
        TimeSpan offset)
        => new OffsetEvent(
            operand,
            offset);
}