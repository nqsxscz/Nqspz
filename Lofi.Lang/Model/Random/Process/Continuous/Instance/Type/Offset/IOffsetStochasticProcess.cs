using Lofi.Lang.Model.Random.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Continuous.Instance.Type.Offset;

public interface IOffsetStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : notnull
{
    IStochasticProcess<T> Operand { get; }
    
    TimeSpan Offset { get; }
    
    Func<DateTime, TimeSpan, DateTime> Offsetter { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IContinuousProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IContinuousProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}