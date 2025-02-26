using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Visitor;

public interface IContinuousProcessVisitor1<TC>
    : IPiecewiseConstantProcessVisitor1<TC>
    where TC : notnull
{
    ITypeConstructor<TC, DateTime> Visit(
        ITimeContinuousProcess process);
    
    ITypeConstructor<TC, T> Visit<T>(
        IEmptyContinuousProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IConstantContinuousProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IOffsetContinuousProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IFlattenContinuousProcess<T> process)
        where T : notnull;

    ITypeConstructor<TC, T2> Visit<T1, T2>(
        ISelectContinuousProcess<T1, T2> process)
        where T1 : notnull
        where T2 : notnull;
    
    ITypeConstructor<TC, T3> Visit<T1, T2, T3>(
        ILiftContinuousProcess<T1, T2, T3> process)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}