using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Random.Temporal.Visitor;

public interface IDiscreteTemporalVisitor<out TResult>
    where TResult : notnull
{
    TResult Visit<T>(
        IDiscretizedTemporal<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IOffsetDiscreteTemporal<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        ISupplierDiscreteTemporal<T> process)
        where T : notnull;
}