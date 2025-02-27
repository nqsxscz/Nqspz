namespace Lofi.Lang.Random.Event.Single.Instance.Type;

public interface IOffsetEvent
    : IEvent
{
    IEvent Operand { get; }

    TimeSpan Offset { get; }
}