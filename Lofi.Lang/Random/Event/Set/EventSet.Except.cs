using Lofi.Lang.Random.Event.Set.Instance.Implementation;
using Lofi.Lang.Random.Event.Set.Instance.Type;

namespace Lofi.Lang.Random.Event.Set;

public static partial class EventSet
{
    public static IEventSet Except(
        this IEventSet left,
        IEventSet right)
        => new BinaryOperationEventSet(
                left,
                right,
                Operator.Except);
}