using Lofi.Lang.Random.Event.Set.Instance.Type;

namespace Lofi.Lang.Random.Event.Set.Instance.Implementation;

internal sealed record SkipEventSet(
    IEventSet Operand,
    int Count)
    : ISkipEventSet;