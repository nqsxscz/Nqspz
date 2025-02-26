using Lofi.Lang.Random.Process.Continuous;
using Lofi.Lang.Random.Process.PiecewiseConstant;
using Lofi.Lang.Random.Sequence;
using Lofi.Lang.Random.Time.Instance.Type;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Time;

public static partial class StoppingTime
{
    public static Func<IStoppingTime, IMaybe<DateTime>>
        Occurrence(DateTime t)
        => stoppingTime 
            => stoppingTime
                .Occurrence(t);

    public static IMaybe<DateTime> Occurrence(
        this IStoppingTime stoppingTime,
        DateTime t)
        => stoppingTime switch 
        {
            IMinimumStoppingTime
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
            IMaximumStoppingTime
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
            IOffsetStoppingTime
                {
                    Operand: var operand,
                    Offset: var offset
                } =>
                operand
                    .Occurrence(t)
                    .Select(dt => dt + offset)
                    .ToMaybe(),
            IPredicateStoppingTime
                {
                    Predicate: var predicate,
                    Index: var index
                } =>
                predicate
                    .StoppingSequence()
                    .Occurrences(t)
                    .Where(s =>
                        predicate.Observe(s)
                            .OrElse(false))
                    .MaybeGet(index),
            IConstantStoppingTime
                {
                    Time: var time
                }
                when time <= t =>
                time.ToMaybe(),
            _ =>
                Maybe.Nothing<DateTime>()
        };
}