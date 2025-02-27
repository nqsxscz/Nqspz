namespace Lofi.Lang.Random.Event.Single.Instance.Type;

public interface IMinimumEvent
    : IEvent
{
    IEvent Left { get; }

    IEvent Right { get; }
}