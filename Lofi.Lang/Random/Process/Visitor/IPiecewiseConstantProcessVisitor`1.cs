using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Visitor;

public interface IPiecewiseConstantProcessVisitor1<TC>
    where TC : notnull
{
    ITypeConstructor<TC, T> Visit<T>(
        IDiscretizedPiecewiseConstantContinuousProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IOffsetPiecewiseConstantContinuousProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        ISupplierPiecewiseConstantContinuousProcess<T> process)
        where T : notnull;
}