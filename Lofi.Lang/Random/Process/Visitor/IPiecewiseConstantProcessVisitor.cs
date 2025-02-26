using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Random.Process.Visitor;

public interface IPiecewiseConstantProcessVisitor<out TResult>
    where TResult : notnull
{
    TResult Visit<T>(
        IDiscretizedPiecewiseConstantContinuousProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IOffsetPiecewiseConstantContinuousProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        ISupplierPiecewiseConstantContinuousProcess<T> process)
        where T : notnull;
}