using Lofi.Lang.Random.Process.Visitor.Observe.Type;

namespace Lofi.Lang.Random.Process.Visitor.Observe.Implementation;

internal sealed record ObserveVisitor(
    DateTime Time) 
    : IObserveVisitor;