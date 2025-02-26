using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface IFlattenProcess<out T> :
    IProcess<T>
    where T : notnull
{
    IProcess<IMaybe<T>> Operand { get; }
    
    ITypeConstructor<TC, T> IProcess<T>.Accept<TC>(
        IProcessVisitor<TC> visitor)
        => visitor.Visit(this);
}