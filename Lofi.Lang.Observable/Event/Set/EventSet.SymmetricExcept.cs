using Lofi.Lang.Observable.Event.Set.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set;

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