using Lofi.Lang.Random.Temporal.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Temporal.Continuous.Instance.Type;

public interface ITimeTemporal
    : ITemporal<DateTime>
{
    TResult ITemporal<DateTime>.Accept<TResult>(
        ITemporalVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, DateTime> ITemporal<DateTime>.Accept<TC>(
        ITemporalVisitor1<TC> visitor)
        => visitor.Visit(this);
}