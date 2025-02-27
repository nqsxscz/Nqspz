using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

public interface IOffsetDiscreteTemporal<out T> :
    IDiscreteTemporal<T>
    where T : notnull
{
    IDiscreteTemporal<T> Operand { get; }

    int Offset { get; }
    
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