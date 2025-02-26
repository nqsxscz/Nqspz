using Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Visitor;

public interface IPiecewiseConstantProcessVisitor1<TC>
    where TC : notnull
{
    ITypeConstructor<TC, T> Visit<T>(
        IDiscretizedPiecewiseConstantStochasticProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IOffsetPiecewiseConstantStochasticProcess<T> process)
        where T : notnull;
}