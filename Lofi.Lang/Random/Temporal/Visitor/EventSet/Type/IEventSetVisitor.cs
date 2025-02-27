using Lofi.Lang.Random.Event.Set;
using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Visitor.EventSet.Type;

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