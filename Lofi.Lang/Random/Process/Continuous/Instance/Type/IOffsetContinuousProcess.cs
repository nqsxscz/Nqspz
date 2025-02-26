using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface IOffsetContinuousProcess<out T>
    : IContinuousProcess<T>
    where T : notnull
{
    IContinuousProcess<T> Operand { get; }

    TimeSpan Offset { get; }
    
    Func<DateTime, TimeSpan, DateTime> Offsetter { get; }
    
    TResult IContinuousProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IContinuousProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}