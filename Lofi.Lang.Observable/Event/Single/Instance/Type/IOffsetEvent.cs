namespace Lofi.Lang.Observable.Event.Single.Instance.Type;

public interface IOffsetEvent
    : IEvent
{
    IEvent Operand { get; }

    TimeSpan Offset { get; }
}