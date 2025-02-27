using Lofi.Lang.Observable.Temporal.Visitor.Observe.Type;

namespace Lofi.Lang.Observable.Temporal.Visitor.Observe.Implementation;

internal sealed record ObserveVisitor(
    DateTime Time) 
    : IObserveVisitor;