using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface ISupplierPiecewiseConstantContinuousProcess<out T> :
    IPiecewiseConstantContinuousProcess<T>
    where T : notnull
{
    ISupplier<T> Supplier { get; }

    string Key { get; }
    
    TResult IContinuousProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T> IContinuousProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
    
    TResult IPiecewiseConstantContinuousProcess<T>.Accept<TResult>(
        IPiecewiseConstantProcessVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T> 
        IPiecewiseConstantContinuousProcess<T>.Accept<TC>(
            IPiecewiseConstantProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}