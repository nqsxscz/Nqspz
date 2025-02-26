using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Visitor;

public interface IProcessVisitor<TC>
    : IStoppedProcessVisitor<TC>
    where TC : notnull
{
    ITypeConstructor<TC, DateTime> Visit(
        ITimeContinuousProcess continuousProcess);
    
    ITypeConstructor<TC, T> Visit<T>(
        IEmptyContinuousProcess<T> continuousProcess)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IConstantContinuousProcess<T> continuousProcess)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IFlattenContinuousProcess<T> continuousProcess)
        where T : notnull;

    ITypeConstructor<TC, T2> Visit<T1, T2>(
        ISelectContinuousProcess<T1, T2> continuousProcess)
        where T1 : notnull
        where T2 : notnull;
    
    ITypeConstructor<TC, T3> Visit<T1, T2, T3>(
        ILiftContinuousProcess<T1, T2, T3> continuousProcess)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull;
}