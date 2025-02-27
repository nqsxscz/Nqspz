using Lofi.Lang.Random.Temporal.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Temporal.Continuous.Instance.Type;

public interface ILiftTemporal<T1, T2, out T3>
    : ITemporal<T3>
    where T1 : notnull
    where T2 : notnull
    where T3 : notnull
{
    ITemporal<T1> Left { get; }

    ITemporal<T2> Right { get; }

    Func<T1, T2, T3> Combinator { get; }
    
    TResult ITemporal<T3>.Accept<TResult>(
        ITemporalVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T3> ITemporal<T3>.Accept<TC>(
        ITemporalVisitor1<TC> visitor)
        => visitor.Visit(this);
}