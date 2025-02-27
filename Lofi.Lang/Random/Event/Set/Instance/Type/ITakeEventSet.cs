namespace Lofi.Lang.Random.Event.Set.Instance.Type;

public interface ITakeEventSet
    : IEventSet
{
    IEventSet Operand { get; }

    int Count { get; }
}