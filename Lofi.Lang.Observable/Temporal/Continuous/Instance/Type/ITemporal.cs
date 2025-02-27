using Lofi.Lang.Observable.Temporal.Continuous.Instance.TypeConstructor;
using Lofi.Lang.Observable.Temporal.Visitor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

public interface ITemporal<out T>
    : ITypeConstructor<ITemporal, T>
    where T : notnull
{
    TResult Accept<TResult>(
        ITemporalVisitor<TResult> visitor)
        where TResult : notnull;
    
    ITypeConstructor<TC, T> Accept<TC>(
        ITemporalVisitor1<TC> visitor)
        where TC : notnull;
}