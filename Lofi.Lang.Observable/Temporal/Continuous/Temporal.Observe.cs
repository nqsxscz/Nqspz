using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Observable.Temporal.Visitor;
using Lofi.Prelude.Data.Control;
using Lofi.Prelude.Data.Control.Instance.Maybe.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static IMaybe<T> Observe<T>(this 
        ITemporal<T> process, 
        DateTime t)
        where T : notnull
        => process
            .Accept(TemporalVisitor.Observe(t))
            .ToMaybe();
}