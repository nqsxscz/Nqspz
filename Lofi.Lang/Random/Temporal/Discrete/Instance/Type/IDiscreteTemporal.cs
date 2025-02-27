using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.TypeConstructor;
using Lofi.Lang.Random.Temporal.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Random.Temporal.Discrete.Instance.Type;

public interface IDiscreteTemporal<out T> :
    ITemporal<T>,
    ITypeConstructor<IDiscreteTemporal, T>
    where T : notnull
{
    TResult Accept<TResult>(
        IDiscreteTemporalVisitor<TResult> visitor)
        where TResult : notnull;
    
    ITypeConstructor<TC, T> Accept<TC>(
        IDiscreteTemporalVisitor1<TC> visitor)
        where TC : notnull;
}