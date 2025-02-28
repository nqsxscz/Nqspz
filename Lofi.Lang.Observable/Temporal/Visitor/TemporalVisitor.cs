using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Temporal.Visitor.EventSet.Implementation;
using Lofi.Lang.Observable.Temporal.Visitor.Observe.Implementation;
using Lofi.Prelude.Data.Control.Instance.Maybe.TypeConstructor;

namespace Lofi.Lang.Observable.Temporal.Visitor;

public static class TemporalVisitor
{
    public static ITemporalVisitor1<IMaybe> 
        Observe(DateTime t)
        => new ObserveVisitor(t);

    public static IDiscreteTemporalVisitor<IEventSet>
        StoppingSequence
        => new EventSetVisitor();
}