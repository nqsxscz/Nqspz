using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Visitor;

public interface ITemporalVisitor<out TResult>
    : IDiscreteTemporalVisitor<TResult>
    where TResult : notnull
{
    TResult Visit(
        ITimeTemporal process);
    
    TResult Visit<T>(
        IEmptyTemporal<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IConstantTemporal<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IOffsetTemporal<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IFlattenTemporal<T> process)
        where T : notnull;

    TResult Visit<T1, T2>(
        ISelectTemporal<T1, T2> process)
        where T1 : notnull
        where T2 : notnull;
    
    TResult Visit<T1, T2, T3>(
        ILiftTemporal<T1, T2, T3> process)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}