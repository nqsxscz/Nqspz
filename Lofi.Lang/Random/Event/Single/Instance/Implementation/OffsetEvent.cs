using Lofi.Lang.Random.Event.Single.Instance.Type;

namespace Lofi.Lang.Random.Event.Single.Instance.Implementation;

internal sealed record OffsetEvent(
    IEvent Operand,
    TimeSpan Offset)
    : IOffsetEvent;