using Lofi.Lang.Observable.Temporal.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

public interface ISelectTemporal<T1, out T2>
    : ITemporal<T2>
    where T1 : notnull
    where T2 : notnull
{
    ITemporal<T1> Operand { get; }

    Func<T1, T2> Selector { get; }
    
    TResult ITemporal<T2>.Accept<TResult>(
        ITemporalVisitor<TResult> visitor)
        => visitor.Visit(this);

    ITypeConstructor<TC, T2> ITemporal<T2>.Accept<TC>(
        ITemporalVisitor1<TC> visitor)
        => visitor.Visit(this);
}