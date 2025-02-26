using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Visitor;

public interface IStoppedProcessVisitor<TC>
    where TC : notnull
{
    ITypeConstructor<TC, T> Visit<T>(
        IDiscretizedPiecewiseConstantContinuousProcess<T> continuousProcess)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IOffsetPiecewiseConstantContinuousProcess<T> continuousProcess)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        ISupplierPiecewiseConstantContinuousProcess<T> continuousProcess)
        where T : notnull;
}