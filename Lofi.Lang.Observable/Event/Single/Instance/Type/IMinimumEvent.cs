namespace Lofi.Lang.Observable.Event.Single.Instance.Type;

public interface IMinimumEvent
    : IEvent
{
    IEvent Left { get; }

    IEvent Right { get; }
}