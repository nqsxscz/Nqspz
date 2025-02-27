using Lofi.Lang.Random.Event.Set.Instance.Type;

namespace Lofi.Lang.Random.Event.Set;

public static partial class EventSet
{
    public static IEventSet SymmetricExcept(
        this IEventSet left,
        IEventSet right)
        => left
            .Except(right)
            .Union(
                right
                    .Except(left));
}