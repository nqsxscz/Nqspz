using Lofi.Lang.Random.Event.Single.Instance.Type;

namespace Lofi.Lang.Random.Event.Single.Instance.Implementation;

internal sealed record ConstantEvent(
    DateTime Time)
    : IConstantEvent;