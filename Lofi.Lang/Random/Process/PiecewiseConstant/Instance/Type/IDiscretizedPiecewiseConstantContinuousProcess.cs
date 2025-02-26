using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface IDiscretizedPiecewiseConstantContinuousProcess<out T> :
    IPiecewiseConstantContinuousProcess<T>
    where T : notnull
{
    IContinuousProcess<T> Operand { get; }
    
    ITypeConstructor<TC, T> IContinuousProcess<T>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}