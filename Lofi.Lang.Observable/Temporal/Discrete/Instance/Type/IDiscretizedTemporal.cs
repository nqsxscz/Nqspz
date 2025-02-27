using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

public interface IDiscretizedTemporal<out T> :
    IDiscreteTemporal<T>
    where T : notnull
{
    ITemporal<T> Operand { get; }
    
    IEventSet EventSet { get; }
    
    TResult ITemporal<T>.Accept<TResult>(
        ITemporalVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T> ITemporal<T>.Accept<TC>(
        ITemporalVisitor1<TC> visitor)
        => visitor.Visit(this);

    TResult IDiscreteTemporal<T>.Accept<TResult>(
        IDiscreteTemporalVisitor<TResult> visitor)
        => visitor.Visit(this);
    
    ITypeConstructor<TC, T> 
        IDiscreteTemporal<T>.Accept<TC>(
            IDiscreteTemporalVisitor1<TC> visitor)
        => visitor.Visit(this);
}