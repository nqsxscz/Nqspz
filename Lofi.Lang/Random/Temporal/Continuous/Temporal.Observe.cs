using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Visitor;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static IMaybe<T> Observe<T>(
        this ITemporal<T> process, 
        DateTime t)
        where T : notnull
        => process
            .Accept(TemporalVisitor.Observe(t))
            .ToMaybe();
}