using Lofi.Lang.Random.Event.Single.Instance.Type;

namespace Lofi.Lang.Random.Event.Single.Instance.Implementation;

internal sealed record MaximumEvent(
    IEvent Left,
    IEvent Right)
    : IMaximumEvent;