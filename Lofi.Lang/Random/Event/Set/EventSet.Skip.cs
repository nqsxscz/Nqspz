using Lofi.Lang.Random.Event.Set.Instance.Implementation;
using Lofi.Lang.Random.Event.Set.Instance.Type;

namespace Lofi.Lang.Random.Event.Set;

public static partial class EventSet
{
    public static IEventSet Skip(
        this IEventSet operand,
        int count)
        => new SkipEventSet(
            operand,
            count);
}