using Lofi.Lang.Trait;

namespace Lofi.Lang.Random.Event.Set.Instance.Type;

public interface IEventSet
    : IManyOccurrable<IEventSet>
{
    static IOrderedEnumerable<DateTime>
        IManyOccurrable<IEventSet>.Occurrences(
            IEventSet sequence,
            DateTime t)
        => sequence.Occurrences(t);
}