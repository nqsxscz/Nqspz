using Lofi.Lang.Random.Temporal.Visitor.Observe.Type;

namespace Lofi.Lang.Random.Temporal.Visitor.Observe.Implementation;

internal sealed record ObserveVisitor(
    DateTime Time) 
    : IObserveVisitor;