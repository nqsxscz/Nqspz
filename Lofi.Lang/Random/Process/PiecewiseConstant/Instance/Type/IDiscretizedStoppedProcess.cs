using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

public interface IDiscretizedStoppedProcess<out T> :
    IStoppedProcess<T>
    where T : notnull
{
    IProcess<T> Operand { get; }
    
    ITypeConstructor<TC, T> IProcess<T>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}