using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Temporal.Visitor;

public interface ITemporalVisitor1<TC>
    : IDiscreteTemporalVisitor1<TC>
    where TC : notnull
{
    ITypeConstructor<TC, DateTime> Visit(
        ITimeTemporal process);
    
    ITypeConstructor<TC, T> Visit<T>(
        IEmptyTemporal<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IConstantTemporal<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IOffsetTemporal<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IFlattenTemporal<T> process)
        where T : notnull;

    ITypeConstructor<TC, T2> Visit<T1, T2>(
        ISelectTemporal<T1, T2> process)
        where T1 : notnull
        where T2 : notnull;
    
    ITypeConstructor<TC, T3> Visit<T1, T2, T3>(
        ILiftTemporal<T1, T2, T3> process)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}