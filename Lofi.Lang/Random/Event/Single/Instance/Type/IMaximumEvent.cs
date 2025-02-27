namespace Lofi.Lang.Random.Event.Single.Instance.Type;

public interface IMaximumEvent
    : IEvent
{
    IEvent Left { get; }

    IEvent Right { get; }
}