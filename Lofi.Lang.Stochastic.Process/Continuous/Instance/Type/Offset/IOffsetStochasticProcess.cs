using Lofi.Lang.Stochastic.Process.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Process.Continuous.Instance.Type.Offset;

public interface IOffsetStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : notnull
{
    IStochasticProcess<T> Operand { get; }
    
    Func<DateTime, DateTime> Offsetter { get; }
    
    TResult IStochasticProcess<T>.Accept<TResult>(
        IStochasticProcessVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T> IStochasticProcess<T>.Accept<TC>(
        IStochasticProcessVisitor1<TC> visitor)
        => visitor.Visit(this);
}