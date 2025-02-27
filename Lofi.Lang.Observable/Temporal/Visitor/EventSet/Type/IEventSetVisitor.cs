using Lofi.Lang.Observable.Event.Set;
using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Visitor.EventSet.Type;

public interface IEventSetVisitor
    : IDiscreteTemporalVisitor<IEventSet>
{
    IEventSet
        IDiscreteTemporalVisitor<IEventSet>.Visit<T>(
            IDiscretizedTemporal<T> process)
        => process
            .EventSet;

    IEventSet
        IDiscreteTemporalVisitor<IEventSet>.Visit<T>(
            IOffsetDiscreteTemporal<T> process)
        => process
            .Operand
            .EventSet();

    IEventSet
        IDiscreteTemporalVisitor<IEventSet>.Visit<T>(
            ISupplierDiscreteTemporal<T> process)
        => process
            .Supplier
            .Times
            .ToEventSet();
}