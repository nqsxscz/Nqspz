using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Visitor;

public interface IStoppedProcessVisitor<TC>
    where TC : notnull
{
    ITypeConstructor<TC, T> Visit<T>(
        IDiscretizedStoppedProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        IOffsetStoppedProcess<T> process)
        where T : notnull;
    
    ITypeConstructor<TC, T> Visit<T>(
        ISupplierStoppedProcess<T> process)
        where T : notnull;
}