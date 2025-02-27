using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Lang.Random.Temporal.Visitor;

namespace Lofi.Lang.Random.Temporal.Discrete;

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