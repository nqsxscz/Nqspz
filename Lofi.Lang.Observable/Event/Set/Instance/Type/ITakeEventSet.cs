namespace Lofi.Lang.Observable.Event.Set.Instance.Type;

public interface ITakeEventSet
    : IEventSet
{
    IEventSet Operand { get; }

    int Count { get; }
}