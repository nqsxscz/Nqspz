using Lofi.Lang.Observable.Event.Set.Instance.Type;

namespace Lofi.Lang.Observable.Event.Set.Instance.Implementation;

internal sealed record SkipEventSet(
    IEventSet Operand,
    int Count)
    : ISkipEventSet;