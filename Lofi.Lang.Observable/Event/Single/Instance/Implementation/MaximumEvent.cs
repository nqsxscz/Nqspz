using Lofi.Lang.Observable.Event.Single.Instance.Type;

namespace Lofi.Lang.Observable.Event.Single.Instance.Implementation;

internal sealed record MaximumEvent(
    IEvent Left,
    IEvent Right)
    : IMaximumEvent;