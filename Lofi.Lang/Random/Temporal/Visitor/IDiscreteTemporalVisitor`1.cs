using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Temporal.Visitor;

public interface IDiscreteTemporalVisitor1<TC>
    where TC : notnull
{
    ITypeConstructor<TC, T> Visit<T>(
        IDiscretizedTemporal<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IOffsetDiscreteTemporal<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        ISupplierDiscreteTemporal<T> process)
        where T : notnull;
}