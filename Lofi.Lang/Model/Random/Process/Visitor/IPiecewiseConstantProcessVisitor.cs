using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Model.Random.Process.Visitor;

public interface IPiecewiseConstantProcessVisitor<out TResult>
    where TResult : notnull
{
    TResult Visit<T>(
        IDiscretizedPiecewiseConstantStochasticProcess<T> process)
        where T : notnull;
    
    TResult Visit<T>(
        IOffsetPiecewiseConstantStochasticProcess<T> process)
        where T : notnull;
}