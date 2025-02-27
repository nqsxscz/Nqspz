namespace Lofi.Lang.Random.Event.Set.Instance.Type;

public interface ISkipEventSet
    : IEventSet
{
    IEventSet Operand { get; }

    int Count { get; }
}