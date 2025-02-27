using Lofi.Lang.Observable.Event.Single.Instance.Type;

namespace Lofi.Lang.Observable.Event.Single.Instance.Implementation;

internal sealed record MinimumEvent(
    IEvent Left,
    IEvent Right)
    : IMinimumEvent;