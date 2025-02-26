using Lofi.Lang.Model.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.PiecewiseConstant.Instance.Type;

public interface IDiscretizedPiecewiseConstantStochasticProcess<out T>
    : IPiecewiseConstantStochasticProcess<T>
    where T : notnull
{
    IStochasticProcess<T> Operand { get; }
    
    ISeq<DateTime> Times { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);

    TResult IPiecewiseConstantStochasticProcess<T>.Accept<TResult>(
        IPiecewiseConstantProcessVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T> 
        IPiecewiseConstantStochasticProcess<T>.Accept<TC>(
            IPiecewiseConstantProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}