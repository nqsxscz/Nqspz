namespace Lofi.Lang.Observable.Event.Single.Instance.Type;

public interface IConstantEvent :
    IEvent
{
    DateTime Time { get; }
}