using Lofi.Lang.Observable.Event.Set;
using Lofi.Lang.Observable.Event.Single.Instance.Type;
using Lofi.Lang.Observable.Temporal.Continuous;
using Lofi.Lang.Observable.Temporal.Discrete;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Observable.Event.Single;

public static partial class Event
{
    public static Func<IEvent, IMaybe<DateTime>>
        Occurrence(DateTime t)
        => stoppingTime 
            => stoppingTime
                .Occurrence(t);

    public static IMaybe<DateTime> Occurrence(
        this IEvent @event,
        DateTime t)
        => @event switch 
        {
            IMinimumEvent
                {
                    Left: var left,
                    Right: var right
                } =>
                left.Occurrence(t)
                    .Lift(
                        right.Occurrence(t),
                        (t1, t2) =>
                            t1 <= t2 ? t1 : t2)
                    .ToMaybe(),
            IMaximumEvent
                {
                    Left: var left,
                    Right: var right
                } =>
                left.Occurrence(t)
                    .Lift(
                        right.Occurrence(t),
                        (t1, t2) =>
                            t1 > t2 ? t1 : t2)
                    .ToMaybe(),
            IOffsetEvent
                {
                    Operand: var operand,
                    Offset: var offset
                } =>
                operand
                    .Occurrence(t)
                    .Select(dt => dt + offset)
                    .ToMaybe(),
            IPredicateEvent
                {
                    Predicate: var predicate,
                    Index: var index
                } =>
                predicate
                    .EventSet()
                    .Occurrences(t)
                    .Where(s =>
                        predicate.Observe(s)
                            .OrElse(false))
                    .MaybeGet(index),
            IConstantEvent
                {
                    Time: var time
                }
                when time <= t =>
                time.ToMaybe(),
            _ =>
                Maybe.Nothing<DateTime>()
        };
}