using Lofi.Lang.Trait;

namespace Lofi.Lang.Random.Sequence.Instance.Type;

public interface IStoppingSequence
    : IOccurrable<IStoppingSequence>
{
    static IOrderedEnumerable<DateTime>
        IOccurrable<IStoppingSequence>.Occurrences(
            IStoppingSequence sequence,
            DateTime t)
        => sequence.Occurrences(t);
}