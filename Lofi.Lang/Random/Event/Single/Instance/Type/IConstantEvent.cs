namespace Lofi.Lang.Random.Event.Single.Instance.Type;

public interface IConstantEvent :
    IEvent
{
    DateTime Time { get; }
}