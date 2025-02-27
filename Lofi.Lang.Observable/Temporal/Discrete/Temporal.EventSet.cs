using Lofi.Lang.Observable.Event.Set.Instance.Type;
using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;
using Lofi.Lang.Observable.Temporal.Visitor;

namespace Lofi.Lang.Observable.Temporal.Discrete;

public static partial class Temporal
{
    public static IEventSet EventSet<T>(
        this IDiscreteTemporal<T> process)
        where T : notnull
        => process
            .Accept(
                TemporalVisitor
                    .StoppingSequence);
}