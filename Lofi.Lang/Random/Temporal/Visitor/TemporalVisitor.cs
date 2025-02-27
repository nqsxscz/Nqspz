using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Temporal.Visitor.EventSet.Implementation;
using Lofi.Lang.Random.Temporal.Visitor.Observe.Implementation;
using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;

namespace Lofi.Lang.Random.Temporal.Visitor;

public static class TemporalVisitor
{
    public static ITemporalVisitor1<IMaybe> 
        Observe(DateTime t)
        => new ObserveVisitor(t);

    public static IDiscreteTemporalVisitor<IEventSet>
        StoppingSequence
        => new EventSetVisitor();
}