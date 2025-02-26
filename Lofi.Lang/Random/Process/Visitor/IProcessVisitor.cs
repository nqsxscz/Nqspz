using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Visitor;

public interface IProcessVisitor<TC>
    : IStoppedProcessVisitor<TC>
    where TC : notnull
{
    ITypeConstructor<TC, DateTime> Visit(
        ITimeProcess process);
    
    ITypeConstructor<TC, T> Visit<T>(
        IEmptyProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IConstantProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IFlattenProcess<T> process)
        where T : notnull;

    ITypeConstructor<TC, T2> Visit<T1, T2>(
        ISelectProcess<T1, T2> process)
        where T1 : notnull
        where T2 : notnull;
    
    ITypeConstructor<TC, T3> Visit<T1, T2, T3>(
        ILiftProcess<T1, T2, T3> process)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}