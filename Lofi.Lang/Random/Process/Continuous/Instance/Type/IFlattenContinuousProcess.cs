using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface IFlattenContinuousProcess<out T> :
    IContinuousProcess<T>
    where T : notnull
{
    IContinuousProcess<IMaybe<T>> Operand { get; }
    
    TResult IContinuousProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T> IContinuousProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}