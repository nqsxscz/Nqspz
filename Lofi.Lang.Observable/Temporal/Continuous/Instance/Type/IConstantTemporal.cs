using Lofi.Lang.Observable.Temporal.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

public interface IConstantTemporal<out T>
    : ITemporal<T>
    where T : notnull
{
    T Value { get; }

    TResult ITemporal<T>.Accept<TResult>(
        ITemporalVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T> ITemporal<T>.Accept<TC>(
        ITemporalVisitor1<TC> visitor)
        => visitor.Visit(this);
}