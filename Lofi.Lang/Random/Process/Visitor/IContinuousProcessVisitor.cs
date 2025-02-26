using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Visitor;

public interface IContinuousProcessVisitor<out TResult>
    : IPiecewiseConstantProcessVisitor<TResult>
    where TResult : notnull
{
    TResult Visit(
        ITimeContinuousProcess process);
    
    TResult Visit<T>(
        IEmptyContinuousProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IConstantContinuousProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IOffsetContinuousProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IFlattenContinuousProcess<T> process)
        where T : notnull;

    TResult Visit<T1, T2>(
        ISelectContinuousProcess<T1, T2> process)
        where T1 : notnull
        where T2 : notnull;
    
    TResult Visit<T1, T2, T3>(
        ILiftContinuousProcess<T1, T2, T3> process)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}